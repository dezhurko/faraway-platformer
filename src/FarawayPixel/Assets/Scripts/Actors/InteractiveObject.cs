using System;
using Faraway.Pixel.Actor.Contracts;
using Faraway.Pixel.Entities.Interaction;
using UnityEngine;

namespace Faraway.Pixel.Actors
{
    /// <summary>
    /// Represent base abstract class for all interactive objects.
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public abstract class InteractiveObject : MonoBehaviour, IInteractiveObject
    {
        /// <inheritdoc/>
        public event Action<InteractiveObjectData> Interact;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Constants.PlayerTag))
            {
                Interact?.Invoke(CreateInteractiveObjectData());
                gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// Creates an instance of an interactive object data object, which is used as an argument in the interact event.
        /// </summary>
        /// <returns>An instance of the interactive object data object.</returns>
        protected abstract InteractiveObjectData CreateInteractiveObjectData();
    }
}
