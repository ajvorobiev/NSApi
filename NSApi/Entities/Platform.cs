namespace NSApiForge.Entities
{
    using RestSharp.Deserializers;

    /// <summary>
    /// Describes a departure platform track.
    /// </summary>
    public class Platform
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Platform"/> is changed.
        /// </summary>
        [DeserializeAs(Name = "wijziging")]
        public bool Changed { get; set; }

        /// <summary>
        /// Gets or sets the value, the number of the platform.
        /// </summary>
        public string Value { get; set; }
    }
}
