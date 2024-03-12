using Faraway.Pixel.Actors;
using Faraway.Pixel.Controllers;
using Faraway.Pixel.Entities.Locomotion;
using UnityEngine;

namespace Faraway.Pixel.Main
{
    public class MobileInputProvider : IInputProvider
    {
        private readonly FloatingJoystick joystick;
        private bool jumped;

        public MobileInputProvider(FloatingJoystick joystick, TouchAreaControl jumpControl)
        {
            this.joystick = joystick;
            jumpControl.Touch += () => jumped = true;
        }

        public UserInput GetInput()
        {
            var horizontal = joystick.Horizontal;
            var vertical = joystick.Vertical;
            var input = new UserInput(horizontal, vertical, jumped, Time.deltaTime);
            jumped = false;
            return input;
        }
        
        
    }
}