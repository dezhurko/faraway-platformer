using System.Collections.Generic;
using System.Linq;
using Faraway.Pixel.Actor.Contracts;
using UnityEngine;

namespace Faraway.Pixel.Actors
{
    public class InteractiveObjectsCollection : MonoBehaviour, IInteractiveObjectsCollection
    {
        [SerializeField]
        private InteractiveObject[] objects;

        public IEnumerable<IInteractiveObject> Objects => objects.Select(o => (IInteractiveObject)o);

        private void Reset()
        {
            objects = GetComponentsInChildren<InteractiveObject>();
        }
    }
}
