namespace Faraway.Pixel.Entities.Buffs
{
    /// <summary>
    /// Represents the data for a speed buff.
    /// </summary>
    public sealed class SpeedBuffData : BuffData
    {
        /// <summary>
        /// Speed change factor that is used for calculating final speed value.
        /// </summary>
        public float SpeedChangeFactor { get; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SpeedBuffData"/> class.
        /// </summary>
        public SpeedBuffData(float speedChangeFactor, float duration) : base(duration)
        {
            SpeedChangeFactor = speedChangeFactor;
        }
    }
}