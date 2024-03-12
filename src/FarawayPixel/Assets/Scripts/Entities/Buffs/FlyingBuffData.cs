namespace Faraway.Pixel.Entities.Buffs
{
    /// <summary>
    /// Represents the data for a flying buff.
    /// </summary>
    public sealed class FlyingBuffData : BuffData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlyingBuffData"/> class.
        /// </summary>
        /// <param name="duration">Duration of the buff.</param>
        public FlyingBuffData(float duration) : base(duration)
        {
        }
    }
}