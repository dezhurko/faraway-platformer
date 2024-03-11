using Faraway.Pixel.Entities.Buffs;
using Faraway.Pixel.Entities.Interaction;
using UnityEngine;

namespace Faraway.Pixel.Actors
{
    public class SpeedBuffInteractiveObject : InteractiveObject
    {
        [SerializeField]
        private float duration;

        [SerializeField]
        private float speedChangeFactor;
        
        protected override InteractiveObjectData CreateInteractiveObjectData() =>
            new BuffInteractiveObjectData(new SpeedBuffData(speedChangeFactor, duration));
    }
}