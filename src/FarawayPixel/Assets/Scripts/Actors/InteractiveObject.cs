using System;
using Faraway.Pixel.Entities.Interaction;
using UnityEngine;

namespace Faraway.Pixel.Actors
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class InteractiveObject : MonoBehaviour
    {
        public event Action<InteractiveObjectData> Interact;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Constants.PlayerTag))
            {
                Interact?.Invoke(CreateInteractiveObjectData());
                gameObject.SetActive(false);
            }
        }

        protected abstract InteractiveObjectData CreateInteractiveObjectData();
    }
}
