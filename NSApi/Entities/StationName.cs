namespace NSApiForge.Entities
{
    /// <summary>
    /// Represents station names
    /// </summary>
    public class StationName
    {
        /// <summary>
        /// Gets or sets the short name.
        /// </summary>
        public string Kort { get; set; }

        /// <summary>
        /// Gets or sets the medium length name.
        /// </summary>
        public string Middel { get; set; }

        /// <summary>
        /// Gets or sets the long name.
        /// </summary>
        public string Lang { get; set; }
    }
}
