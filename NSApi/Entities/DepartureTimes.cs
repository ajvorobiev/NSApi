namespace NSApiForge.Entities
{
    using System.Collections.Generic;

    public abstract class DepartureTimes
    {
        /// <summary>
        /// Gets or sets the times.
        /// </summary>
        public List<Train> Times { get; set; }
    }
}
