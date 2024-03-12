using System;
using Faraway.Pixel.Actor.Contracts;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Faraway.Pixel.Actors
{
    /// <summary>
    /// Represents a touch area control in the game.
    /// </summary>
    public class TouchAreaControl : MonoBehaviour, IPointerDownHandler, ITouchAreaControl
    {
        /// <inheritdoc/>
        public event Action Touch;

        /// <inheritdoc/>
        public void OnPointerDown(PointerEventData eventData)
        {
            Touch?.Invoke();
        }
    }
}
