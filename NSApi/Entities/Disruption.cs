namespace NSApiForge.Entities
{
    using System.Xml.Serialization;

    using RestSharp.Deserializers;

    /// <summary>
    /// Common abstract class for disruptions
    /// </summary>
    [XmlRoot(ElementName = "Storing")]
    public abstract class Disruption
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the route.
        /// </summary>
        [DeserializeAs(Name = "Traject")]
        public string Route { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        [DeserializeAs(Name = "Bericht")]
        public string Message { get; set; }
    }
}
