using System;
using Faraway.Pixel.Entities.Locomotion;

namespace Faraway.Pixel.Entities
{
    public class Player
    {
        public int CollectedItemsCount { get; private set; }

        public int TotalItemsCount => 10;

        public LocomotionSystem Locomotion { get; private set; }

        public LocomotionParameters LocomotionParameters { get; } = new ();

        public event Action<int> ItemCollected;

        public void SetLocomotion(LocomotionSystem locomotion)
        {
            Locomotion = locomotion;
        }

        public void CollectItem(int amount)
        {
            CollectedItemsCount += amount;
            ItemCollected?.Invoke(amount);
        }
    }
}