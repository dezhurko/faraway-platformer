using System.Collections.Generic;
using System.Linq;
using Faraway.Pixel.Actor.Contracts;
using UnityEngine;

namespace Faraway.Pixel.Actors
{
    /// <summary>
    /// Represents a collection of interactive objects in the game.
    /// </summary>
    public class InteractiveObjectsCollection : MonoBehaviour, IInteractiveObjectsCollection
    {
        [SerializeField]
        private InteractiveObject[] objects;

        /// <inheritdoc/>
        public IEnumerable<IInteractiveObject> Objects => objects.Select(o => (IInteractiveObject)o);

        private void Reset()
        {
            objects = GetComponentsInChildren<InteractiveObject>();
        }
    }
}
