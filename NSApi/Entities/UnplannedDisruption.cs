namespace NSApiForge.Entities
{
    using System;
    using System.Xml.Serialization;

    using RestSharp.Deserializers;

    /// <summary>
    /// Represents an unplanned disruption.
    /// </summary>
    [XmlRoot(ElementName = "Storing")]
    public class UnplannedDisruption : Disruption
    {
        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        [DeserializeAs(Name = "Reden")]
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        [DeserializeAs(Name = "Datum")]
        public DateTime Date { get; set; }
    }
}
