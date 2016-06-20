namespace NSApiForge.Entities
{
    using System;

    using RestSharp.Deserializers;

    public class Train
    {
        public int RitNummer { get; set; }
        public DateTime VertrekTijd { get; set; }
        public string VertrekVertraging { get; set; }
        public string VertrekVertragingTekst { get; set; }
        public string EindBestemming { get; set; }
        public string TreinSoort { get; set; }
        public string RouteTekst { get; set; }
        public string Vervoerder { get; set; }
        public Platform VertrekSpoor { get; set; }
        public string ReisTip { get; set; }
        public string Comments { get; set; }
    }

    public class Platform
    {
        [DeserializeAs(Name = "wijziging")]
        public bool PlatformChange { get; set; }
        public string Value { get; set; }
    }
}
