namespace NSApiForge
{
    /// <summary>
    /// The settings.
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Gets or sets the API username.
        /// </summary>
        public string ApiUsername { get; set; }

        /// <summary>
        /// Gets or sets the API password.
        /// </summary>
        public string ApiPassword { get; set; }

        /// <summary>
        /// Gets or sets the API base URL.
        /// </summary>
        public string ApiBaseUrl { get; set; }

        /// <summary>
        /// Gets or sets the API route to stations service.
        /// </summary>
        public string ApiStationsService { get; set; }

        /// <summary>
        /// Gets or sets the API route to departure times service.
        /// </summary>
        public string ApiDepartureTimesService { get; set; }

        /// <summary>
        /// Gets or sets the API route to disruption service.
        /// </summary>
        public string ApiDisruptionService { get; set; }
    }
}
