using System;
using Faraway.Pixel.Actors;
using UnityEngine;

namespace Faraway.Pixel.Controllers
{
    public class InteractiveObjectsCollection : MonoBehaviour
    {
        [SerializeField]
        private InteractiveObject[] objects;

        public InteractiveObject[] Objects => objects;

        private void Reset()
        {
            objects = GetComponentsInChildren<InteractiveObject>();
        }
    }
}
