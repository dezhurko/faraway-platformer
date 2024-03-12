using System;

namespace Faraway.Pixel.Actor.Contracts
{
    /// <summary>
    /// Represents interface for the touch area control.
    /// </summary>
    public interface ITouchAreaControl
    {
        /// <summary>
        /// Raises this event when user touches the screen in the configured area.
        /// </summary>
        event Action Touch;
    }
}