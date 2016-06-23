namespace NSApiForge.Entities
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    using RestSharp.Deserializers;

    [XmlRoot(ElementName = "Storingen")]
    public class DisruptionCollection
    {
        [XmlElement(ElementName = "Ongepland")]
        public UnplannedDisruptionCollection Unplanned { get; set; }

        [XmlElement(ElementName = "Gepland")]
        public PlannedDisruptionCollection Planned { get; set; }
    }

    [XmlRoot(ElementName = "Ongepland")]
    public class UnplannedDisruptionCollection
    {
        [XmlElement(ElementName = "Storing")]
        public List<UnplannedDisruption> Unplanned { get; set; }
    }

    [XmlRoot(ElementName = "Gepland")]
    public class PlannedDisruptionCollection
    {
        [XmlElement(ElementName = "Storing")]
        public List<PlannedDisruption> Unplanned { get; set; }
    }
}
