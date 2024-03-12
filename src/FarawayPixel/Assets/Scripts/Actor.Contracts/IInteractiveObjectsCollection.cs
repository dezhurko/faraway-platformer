using System.Collections.Generic;

namespace Faraway.Pixel.Actor.Contracts
{
    public interface IInteractiveObjectsCollection
    {
        IEnumerable<IInteractiveObject> Objects { get; }
    }
}