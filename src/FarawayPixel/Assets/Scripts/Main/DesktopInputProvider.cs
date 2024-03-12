using Faraway.Pixel.Controllers;
using Faraway.Pixel.Entities.Locomotion;
using UnityEngine;

namespace Faraway.Pixel.Main
{
    /// <summary>
    /// Represents the desktop input provider.
    /// </summary>
    public class DesktopInputProvider : IInputProvider
    {
        /// <inheritdoc/>
        public UserInput GetInput()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            var jump = Input.GetKeyDown(KeyCode.Space);
            return new UserInput(horizontal, vertical, jump);
        }
    }
}