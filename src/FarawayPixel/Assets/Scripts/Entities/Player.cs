using System;
using Faraway.Pixel.Entities.Locomotion;

namespace Faraway.Pixel.Entities
{
    /// <summary>
    /// Represents the player entity.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Gets the number of collected items.
        /// </summary>
        public int CollectedItemsCount { get; private set; }

        /// <summary>
        /// Gets the total number of items to collect.
        /// </summary>
        public int TotalItemsCount => 10;

        /// <summary>
        /// Gets the current locomotion system.
        /// </summary>
        public LocomotionSystem Locomotion { get; private set; }

        /// <summary>
        /// Gets the locomotion parameters.
        /// </summary>
        public LocomotionParameters LocomotionParameters { get; } = new ();

        /// <summary>
        /// Rises when an item is collected.
        /// </summary>
        public event Action<int> ItemCollected;

        /// <summary>
        /// Sets the locomotion system.
        /// </summary>
        public void SetLocomotion(LocomotionSystem locomotion)
        {
            Locomotion = locomotion;
        }

        /// <summary>
        /// Collects an item.
        /// </summary>
        public void CollectItem(int amount)
        {
            CollectedItemsCount += amount;
            ItemCollected?.Invoke(amount);
        }
    }
}