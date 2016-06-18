namespace NSApiForge
{
    using System;
    using System.Collections.Generic;

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
        /// Gets full response of the stations API.
        /// </summary>
        /// <returns>The full response of the stations API.</returns>
        public static List<Station> GetStations()
        {
            var client = CreateNSApiClient();
            var response = client.Execute(CreateStationRestRequest());

            CheckResponseForErrors(response);

            return DeserializeXml<List<Station>>(response);
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

        private static RestRequest CreateStationRestRequest()
        {
            return new RestRequest(SettingsManager.Instance.Settings.ApiStationsService, Method.GET);
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
