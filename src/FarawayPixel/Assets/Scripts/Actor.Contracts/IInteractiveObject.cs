using System;
using Faraway.Pixel.Entities.Interaction;

namespace Faraway.Pixel.Actor.Contracts
{
    /// <summary>
    /// Represents interface for all interactive objects in the game.
    /// </summary>
    public interface IInteractiveObject
    {
        /// <summary>
        /// Raises this event when the player interacts with the interactive object.
        /// </summary>
        event Action<InteractiveObjectData> Interact;
    }
}