using UnityEngine;

namespace Faraway.Pixel.Entities.Locomotion
{
    public class FlyingLocomotionSystem : LocomotionSystem
    {
        private const float Speed = 5f; 
        
        private bool isGrounded;
        private float moveDirection;
        
        public FlyingLocomotionSystem(ILocomotionActor actor, ISpeedFactorProvider speedFactorProvider) 
            : base(actor, speedFactorProvider)
        {
        }

        public override void Update(UserInput input)
        {
            if (Mathf.Abs(input.Horizontal) > Mathf.Epsilon)
            {
                moveDirection = Mathf.Sign(input.Horizontal);
            }

            Actor.Velocity = new Vector2(
                moveDirection * Speed * SpeedFactorProvider.SpeedFactor, 
                input.Vertical * Speed * SpeedFactorProvider.SpeedFactor);
        }
    }
}