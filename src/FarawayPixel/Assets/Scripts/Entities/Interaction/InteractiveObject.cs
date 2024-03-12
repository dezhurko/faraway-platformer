namespace Faraway.Pixel.Entities.Interaction
{
    /// <summary>
    /// Represents an interactive object.
    /// </summary>
    public abstract class InteractiveObject
    {
        /// <summary>
        /// Is called when the player interacts with the object.
        /// </summary>
        public abstract void Interact();
    }
}