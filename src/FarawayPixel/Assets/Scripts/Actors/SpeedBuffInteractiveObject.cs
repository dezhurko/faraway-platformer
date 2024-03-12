using Faraway.Pixel.Entities.Buffs;
using Faraway.Pixel.Entities.Interaction;
using UnityEngine;

namespace Faraway.Pixel.Actors
{
    /// <summary>
    /// Represents an interactive object that grants a speed buff to the player upon interaction.
    /// </summary>
    public class SpeedBuffInteractiveObject : InteractiveObject
    {
        [SerializeField]
        private float duration;

        [SerializeField]
        private float speedChangeFactor;
        
        /// <inheritdoc/>
        protected override InteractiveObjectData CreateInteractiveObjectData() =>
            new BuffInteractiveObjectData(new SpeedBuffData(speedChangeFactor, duration));
    }
}