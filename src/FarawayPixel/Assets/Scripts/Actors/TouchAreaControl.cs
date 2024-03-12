using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Faraway.Pixel.Actors.UI
{
    public class TouchAreaControl : MonoBehaviour, IPointerDownHandler
    {
        public event Action Touch;

        public void OnPointerDown(PointerEventData eventData)
        {
            Touch?.Invoke();
        }
    }
}
