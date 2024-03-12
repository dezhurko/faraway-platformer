namespace Faraway.Pixel.Entities.Buffs
{
    /// <summary>
    /// Represents the data for a buff.
    /// </summary>
    public abstract class BuffData
    {
        /// <summary>
        /// The duration of the buff.
        /// </summary>
        public float Duration { get;  }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BuffData"/> class.
        /// </summary>
        /// <param name="duration">Duration of the buff.</param>
        protected BuffData(float duration)
        {
            Duration = duration;
        }
    }
}