namespace Faraway.Pixel.Entities.Buffs
{
    public sealed class SpeedBuffData : BuffData
    {
        public float SpeedChangeFactor { get; }
        
        public SpeedBuffData(float speedChangeFactor, float duration) : base(duration)
        {
            SpeedChangeFactor = speedChangeFactor;
        }
    }
}