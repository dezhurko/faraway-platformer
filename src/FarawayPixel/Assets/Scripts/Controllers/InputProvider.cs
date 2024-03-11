using Faraway.Pixel.Entities.Locomotion;
using UnityEngine;

namespace Faraway.Pixel.Controllers
{
    public class InputProvider : IInputProvider
    {
        public UserInput GetInput()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            var jump = Input.GetKeyDown(KeyCode.Space);
            return new UserInput(horizontal, vertical, jump, Time.deltaTime);
        }
    }
}