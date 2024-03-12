using Faraway.Pixel.Entities.Interaction;
using UnityEngine;

namespace Faraway.Pixel.Actors
{
    /// <summary>
    /// Represents an interactive object that can be collected by the player.
    /// </summary>
    public class CollectableInteractiveObject : InteractiveObject
    {
        [SerializeField]
        private int amount;
        
        /// <inheritdoc/>
        protected override InteractiveObjectData CreateInteractiveObjectData()
        {
            return new CollectableObjectData(amount);
        }
    }
}