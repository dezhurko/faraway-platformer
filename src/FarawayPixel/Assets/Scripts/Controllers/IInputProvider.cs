using Faraway.Pixel.Entities.Locomotion;

namespace Faraway.Pixel.Controllers
{
    /// <summary>
    /// Defines a provider for user input.
    /// </summary>
    public interface IInputProvider
    {
        /// <summary>
        /// Retrieves the current user input.
        /// </summary>
        /// <returns>The current user input.</returns>
        UserInput GetInput();
    }
}