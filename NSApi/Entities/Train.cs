namespace NSApiForge.Entities
{
    using System;

    using RestSharp.Deserializers;

    /// <summary>
    /// Describes a departing train.
    /// </summary>
    public class Train
    {
        /// <summary>
        /// Gets or sets the number of the ride.
        /// </summary>
        [DeserializeAs(Name = "RitNummer")]
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets the departure time.
        /// </summary>
        [DeserializeAs(Name = "VertrekTijd")]
        public DateTime DepartureTime { get; set; }

        /// <summary>
        /// Gets or sets the delay.
        /// </summary>
        [DeserializeAs(Name = "VertrekVertraging")]
        public string Delay { get; set; }

        /// <summary>
        /// Gets or sets the delay text.
        /// </summary>
        [DeserializeAs(Name = "VertrekVertragingTekst")]
        public string DelayText { get; set; }

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        [DeserializeAs(Name = "EindBestemming")]
        public string Destination { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [DeserializeAs(Name = "TreinSoort")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the route description.
        /// </summary>
        [DeserializeAs(Name = "RouteTekst")]
        public string RouteDescription { get; set; }

        /// <summary>
        /// Gets or sets the carrier.
        /// </summary>
        [DeserializeAs(Name = "Vervoerder")]
        public string Carrier { get; set; }

        /// <summary>
        /// Gets or sets the platform.
        /// </summary>
        [DeserializeAs(Name = "VertrekSpoor")]
        public Platform Platform { get; set; }

        /// <summary>
        /// Gets or sets the tip in case of delay.
        /// </summary>
        [DeserializeAs(Name = "ReisTip")]
        public string Tip { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        public string Comments { get; set; }
    }
}
