namespace Faraway.Pixel.Entities.Interaction
{
    public class CollectableObjectData : InteractiveObjectData
    {
        public int Amount { get; }
        
        public CollectableObjectData(int amount)
        {
            Amount = amount;
        }
    }
}