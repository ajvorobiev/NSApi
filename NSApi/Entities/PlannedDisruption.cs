namespace NSApiForge.Entities
{
    using System.Xml.Serialization;

    using RestSharp.Deserializers;

    /// <summary>
    /// Represents a planned disruptions.
    /// </summary>
    [XmlRoot(ElementName = "Storing")]
    public class PlannedDisruption : Disruption
    {
        /// <summary>
        /// Gets or sets the period.
        /// </summary>
        [DeserializeAs(Name = "Periode")]
        public string Period { get; set; }

        /// <summary>
        /// Gets or sets the advice.
        /// </summary>
        [DeserializeAs(Name = "Advies")]
        public string Advice { get; set; }

        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        [DeserializeAs(Name = "Oorzaak")]
        public string Reason { get; set; }

        [DeserializeAs(Name = "Vertraging")]
        public string Delay { get; set; }
        
    }
}
