namespace NSApiForge.Entities
{
    using RestSharp.Deserializers;

    /// <summary>
    /// Represents station names
    /// </summary>
    public class StationName
    {
        /// <summary>
        /// Gets or sets the short name.
        /// </summary>
        [DeserializeAs(Name = "Kort")]
        public string Short { get; set; }

        /// <summary>
        /// Gets or sets the medium length name.
        /// </summary>
        [DeserializeAs(Name = "Middel")]
        public string Medium { get; set; }

        /// <summary>
        /// Gets or sets the long name.
        /// </summary>
        [DeserializeAs(Name = "Lang")]
        public string Long { get; set; }
    }
}
