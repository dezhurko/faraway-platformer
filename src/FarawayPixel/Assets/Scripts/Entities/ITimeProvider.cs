namespace Faraway.Pixel.Entities
{
    /// <summary>
    /// Represents a time provider interface.
    /// </summary>
    public interface ITimeProvider
    {
        /// <summary>
        /// Gets the current time.
        /// </summary>
        float Now { get; }
    }
}