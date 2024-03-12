using Faraway.Pixel.Entities.Buffs;
using Faraway.Pixel.Entities.Interaction;
using UnityEngine;

namespace Faraway.Pixel.Actors
{
    /// <summary>
    /// Represents an interactive object that grants a flying buff to the player upon interaction.
    /// </summary>
    public class FlyingBuffInteractiveObject : InteractiveObject
    {
        [SerializeField]
        private float duration;
        
        /// <inheritdoc/>
        protected override InteractiveObjectData CreateInteractiveObjectData() =>
            new BuffInteractiveObjectData(new FlyingBuffData(duration));
    }
}