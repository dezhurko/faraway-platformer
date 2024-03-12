using Faraway.Pixel.Entities.Buffs;

namespace Faraway.Pixel.Entities.Interaction
{
    /// <summary>
    /// Represents the data for a buff interactive object.
    /// </summary>
    public class BuffInteractiveObjectData : InteractiveObjectData
    {
        /// <summary>
        /// Buff data.
        /// </summary>
        public BuffData BuffData { get; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BuffInteractiveObjectData"/> class.
        /// </summary>
        public BuffInteractiveObjectData(BuffData data)
        {
            BuffData = data;
        }
    }
}