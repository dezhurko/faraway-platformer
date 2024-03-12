using System;
using Faraway.Pixel.Actor.Contracts;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Faraway.Pixel.Actors
{
    public class TouchAreaControl : MonoBehaviour, IPointerDownHandler, ITouchAreaControl
    {
        public event Action Touch;

        public void OnPointerDown(PointerEventData eventData)
        {
            Touch?.Invoke();
        }
    }
}
