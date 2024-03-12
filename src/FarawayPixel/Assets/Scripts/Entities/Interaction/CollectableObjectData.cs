namespace Faraway.Pixel.Entities.Interaction
{
    /// <summary>
    /// Represents the data for a collectable object.
    /// </summary>
    public class CollectableObjectData : InteractiveObjectData
    {
        /// <summary>
        /// Gets the amount of the collectable object.
        /// </summary>
        public int Amount { get; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectableObjectData"/> class.
        /// </summary>
        public CollectableObjectData(int amount)
        {
            Amount = amount;
        }
    }
}