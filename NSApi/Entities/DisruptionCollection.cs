namespace NSApiForge.Entities
{
    using System.Collections.Generic;

    using RestSharp.Deserializers;

    /// <summary>
    /// A collection of disruptions.
    /// </summary>
    [DeserializeAs(Name = "Storingen")]
    public class DisruptionCollection
    {
        [DeserializeAs(Name= "Ongepland")]
        public UnplannedDisruptionCollection Unplanned { get; set; }

        [DeserializeAs(Name = "Gepland")]
        public PlannedDisruptionCollection Planned { get; set; }
    }

    /// <summary>
    /// A collection of unplanned disruptions.
    /// </summary>
    [DeserializeAs(Name = "Ongepland")]
    public class UnplannedDisruptionCollection
    {
        /// <summary>
        /// Gets or sets the value. In this case the list of all unplanned disruptions.
        /// </summary>
        public List<UnplannedDisruption> Value { get; set; }
    }

    /// <summary>
    /// A collection of planned disruptions.
    /// </summary>
    [DeserializeAs(Name = "Gepland")]
    public class PlannedDisruptionCollection
    {
        /// <summary>
        /// Gets or sets the value. In this case the list of all planned disruptions.
        /// </summary>
        public List<PlannedDisruption> Value { get; set; }
    }
}
