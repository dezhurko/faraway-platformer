using Faraway.Pixel.Actor.Contracts;
using Faraway.Pixel.Controllers;
using Faraway.Pixel.Entities.Locomotion;

namespace Faraway.Pixel.Main
{
    /// <summary>
    /// Represents the mobile input provider.
    /// </summary>
    public class MobileInputProvider : IInputProvider
    {
        private readonly FloatingJoystick joystick;
        private bool jumped;

        /// <summary>
        /// Initializes a new instance of the <see cref="MobileInputProvider"/> class.
        /// </summary>
        /// <param name="joystick">The reference to the joystick.</param>
        /// <param name="jumpControl">The reference to the jump button.</param>
        public MobileInputProvider(FloatingJoystick joystick, ITouchAreaControl jumpControl)
        {
            this.joystick = joystick;
            jumpControl.Touch += () => jumped = true;
        }

        /// <inheritdoc/>
        public UserInput GetInput()
        {
            var horizontal = joystick.Horizontal;
            var vertical = joystick.Vertical;
            var input = new UserInput(horizontal, vertical, jumped);
            jumped = false;
            return input;
        }
        
        
    }
}