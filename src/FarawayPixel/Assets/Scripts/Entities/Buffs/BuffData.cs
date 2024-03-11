namespace Faraway.Pixel.Entities.Buffs
{
    public abstract class BuffData
    {
        public float Duration { get;  }
        
        protected BuffData(float duration)
        {
            Duration = duration;
        }
    }
}