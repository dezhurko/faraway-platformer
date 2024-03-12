using System;
using Faraway.Pixel.Entities.Locomotion;

namespace Faraway.Pixel.Entities
{
    public class Player : ISpeedFactorProvider
    {
        public const float DefaultSpeedFactor = 1f;
        
        private float speedFactor = DefaultSpeedFactor;

        public float SpeedFactor => speedFactor;

        public int CollectedItemsCount { get; private set; }

        public int TotalItemsCount { get; } = 10;

        public LocomotionSystem Locomotion { get; private set; }

        public event Action<int> ItemCollected;

        public void ChangeSpeed(float factor)
        {
            speedFactor = factor;
        }

        public void ResetSpeed()
        {
            speedFactor = DefaultSpeedFactor;
        }

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