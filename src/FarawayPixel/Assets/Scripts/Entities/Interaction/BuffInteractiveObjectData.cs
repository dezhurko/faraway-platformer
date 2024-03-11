using Faraway.Pixel.Entities.Buffs;

namespace Faraway.Pixel.Entities.Interaction
{
    public class BuffInteractiveObjectData : InteractiveObjectData
    {
        public BuffData BuffData { get; }
        
        public BuffInteractiveObjectData(BuffData data)
        {
            BuffData = data;
        }
    }
}