using Faraway.Pixel.Entities.Buffs;
using Faraway.Pixel.Entities.Interaction;
using UnityEngine;

namespace Faraway.Pixel.Actors
{
    public class FlyingBuffInteractiveObject : InteractiveObject
    {
        [SerializeField]
        private float duration;
        
        protected override InteractiveObjectData CreateInteractiveObjectData() =>
            new BuffInteractiveObjectData(new FlyingBuffData(duration));
    }
}