namespace NSApiForge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NSApiForge.Entities;

    using RestSharp;
    using RestSharp.Authenticators;
    using RestSharp.Deserializers;

    /// <summary>
    /// The static class to make requests to the NS API
    /// </summary>
    public static class NSApi
    {
        /// <summary>
        /// Gets the list of stations by name.
        /// </summary>
        /// <param name="name">The name to searc by.</param>
        /// <returns>The list of stations.</returns>
        public static List<Station> GetStationsByName(string name)
        {
            var allStations = GetStations();
            return allStations.Where(s => s.Name.Short.ToLower().Contains(name.ToLower()) || s.Name.Medium.ToLower().Contains(name.ToLower()) || s.Name.Long.ToLower().Contains(name.ToLower())).ToList();
        } 

        /// <summary>
        /// Gets deserialized response of the stations API.
        /// </summary>
        /// <returns>The full response of the stations API.</returns>
        /// <exception cref="ApplicationException">The exception thrown in case the response contains errors.</exception>
        public static List<Station> GetStations()
        {
            var client = CreateNSApiClient();
            var response = client.Execute(CreateStationRestRequest());

            CheckResponseForErrors(response);

            return DeserializeXml<List<Station>>(response);
        }

        /// <summary>
        /// Gets deserialized response of the departures API.
        /// </summary>
        /// <returns>The deserialized response of the departures API.</returns>
        /// <exception cref="ApplicationException">The exception thrown in case the response contains errors.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="station"/> is <see langword="null" />.</exception>
        public static List<DepartingTrain> GetDepartureTimes(string station)
        {
            if (string.IsNullOrEmpty(station))
            {
                throw new ArgumentNullException("station");
            }

            var client = CreateNSApiClient();
            var response = client.Execute(CreateDepartureTimeRestRequest(station));

            CheckResponseForErrors(response);

            var depTimes = DeserializeXml<List<DepartingTrain>>(response);

            return depTimes;
        }

        /// <summary>
        /// Gets deserialized response of the disruptions API.
        /// </summary>
        /// <returns>The deserialized response of the disruptions API.</returns>
        /// <exception cref="ApplicationException">The exception thrown in case the response contains errors.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="station"/> is <see langword="null" />.</exception>
        public static DisruptionCollection GetDisruptions(string station, bool actual = true, bool unplanned = true)
        {
            if (string.IsNullOrEmpty(station))
            {
                throw new ArgumentNullException("station");
            }

            var client = CreateNSApiClient();
            var response = client.Execute(CreateDisruptionRestRequest(station, actual, unplanned));

            CheckResponseForErrors(response);

            var disruptions = DeserializeXml<DisruptionCollection>(response);

            return disruptions;
        }

        /// <summary>
        /// Gets deserialized response of the departures API.
        /// </summary>
        /// <returns>The deserialized response of the departures API filtered on destination.</returns>
        /// <exception cref="ApplicationException">The exception thrown in case the response contains errors.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="station"/> is <see langword="null" />.</exception>
        public static List<DepartingTrain> GetDepartureTimesByDestination(string station, List<string> destinations)
        {
            var allDepartures = GetDepartureTimes(station);

            var result = new List<DepartingTrain>();

            foreach (var destination in destinations)
            {
                result.AddRange(allDepartures.Where(d => d.Destination.ToLower().Contains(destination.ToLower())).ToList());
            }

            return result;
        }

        /// <summary>
        /// Deserializes the XML into the required objects.
        /// </summary>
        /// <typeparam name="T">The type of object to deserialize to.</typeparam>
        /// <param name="response">The response to deserialize (must contain XML).</param>
        /// <returns>The fully deserialized objects.</returns>
        public static T DeserializeXml<T>(IRestResponse response)
        {
            var deserializer = new XmlDeserializer();
            return deserializer.Deserialize<T>(response);
        }

        /// <summary>
        /// Checks the response for errors.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <exception cref="ApplicationException">The exception thrown in case the response contains errors.</exception>
        private static void CheckResponseForErrors(IRestResponse response)
        {
            if (response.ErrorException != null)
            {
                var message = "Error retrieving response. Check inner details for more info.";
                throw new ApplicationException(message, response.ErrorException);
            }
        }

        /// <summary>
        /// Creates the REST request to query all stations.
        /// </summary>
        /// <returns>The REST request for a stations query.</returns>
        private static RestRequest CreateStationRestRequest()
        {
            return new RestRequest(SettingsManager.Instance.Settings.ApiStationsService, Method.GET);
        }

        /// <summary>
        /// Creates the REST request to query departure times of a station.
        /// </summary>
        /// <returns>The REST request for a station departure times.</returns>
        private static RestRequest CreateDepartureTimeRestRequest(string station)
        {
            var request = new RestRequest(string.Format("{0}?station={{station}}",SettingsManager.Instance.Settings.ApiDepartureTimesService), Method.GET);
            request.AddParameter("station", station, ParameterType.UrlSegment);

            return request;
        }

        /// <summary>
        /// Creates the REST request to query disruptions of a station.
        /// </summary>
        /// <returns>The REST request for a station departure times.</returns>
        private static RestRequest CreateDisruptionRestRequest(string station, bool actual, bool unplanned)
        {
            var request = new RestRequest(string.Format("{0}?station={{station}}&actual={{actual}}&unplanned={{unplanned}}", SettingsManager.Instance.Settings.ApiDisruptionService), Method.GET);
            request.AddParameter("station", station, ParameterType.UrlSegment);
            request.AddParameter("actual", actual.ToString().ToLower(), ParameterType.UrlSegment);
            request.AddParameter("unplanned", unplanned.ToString().ToLower(), ParameterType.UrlSegment);

            return request;
        }

        /// <summary>
        /// Creates the REST client connected to the NS API.
        /// </summary>
        /// <returns>The NS API REST client.</returns>
        private static RestClient CreateNSApiClient()
        {
            return CreateClient(
                SettingsManager.Instance.Settings.ApiBaseUrl,
                SettingsManager.Instance.Settings.ApiUsername,
                SettingsManager.Instance.Settings.ApiPassword);
        }

        /// <summary>
        /// Create a REST client to the specified url with the specified credentials.
        /// </summary>
        /// <param name="baseUrl">The base URL to connect to.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>The REST client initialized with the specified parameters.</returns>
        private static RestClient CreateClient(string baseUrl, string username, string password)
        {
            return new RestClient(baseUrl)
            {
                Authenticator = new HttpBasicAuthenticator(username, password)
            };
        } 
    }
}
