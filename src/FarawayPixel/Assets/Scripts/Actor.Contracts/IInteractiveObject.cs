using System;
using Faraway.Pixel.Entities.Interaction;

namespace Faraway.Pixel.Actor.Contracts
{
    public interface IInteractiveObject
    {
        event Action<InteractiveObjectData> Interact;
    }
}