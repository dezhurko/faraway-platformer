using System.Collections.Generic;

namespace Faraway.Pixel.Actor.Contracts
{
    /// <summary>
    /// Represents the container for all interactive objects in the scene.
    /// </summary>
    public interface IInteractiveObjectsCollection
    {
        /// <summary>
        /// Gets enumeration of all interactive objects in the scene.
        /// </summary>
        IEnumerable<IInteractiveObject> Objects { get; }
    }
}