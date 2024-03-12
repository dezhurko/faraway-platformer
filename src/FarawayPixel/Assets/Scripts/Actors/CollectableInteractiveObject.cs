using Faraway.Pixel.Entities.Interaction;
using UnityEngine;

namespace Faraway.Pixel.Actors
{
    public class CollectableInteractiveObject : InteractiveObject
    {
        [SerializeField]
        private int amount;
        
        protected override InteractiveObjectData CreateInteractiveObjectData()
        {
            return new CollectableObjectData(amount);
        }
    }
}