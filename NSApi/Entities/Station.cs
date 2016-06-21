namespace NSApiForge.Entities
{
    using System.Collections.Generic;

    using RestSharp.Deserializers;

    /// <summary>
    /// The Station entity
    /// </summary>
    public class Station
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the type of the station.
        /// </summary>
        public StationType Type { get; set; }

        /// <summary>
        /// Gets or sets the names of the station.
        /// </summary>
        [DeserializeAs(Name = "Namen")]
        public StationName Name { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        [DeserializeAs(Name = "Land")]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the UI code.
        /// </summary>
        public long UICode { get; set; }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        public double Lat { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        public double Lon { get; set; }

        /// <summary>
        /// Gets or sets the synonyms.
        /// </summary>
        /// <remarks>
        /// DeserializeAs attribute does not work on this property for some reason.
        /// </remarks>
        public List<string> Synoniemen { get; set; }
    }
}