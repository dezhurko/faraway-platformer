using UnityEngine;

namespace Faraway.Pixel.Entities.Locomotion
{
    public class DefaultLocomotionSystem : LocomotionSystem
    {
        private const float Speed = 5f; 
        private const float JumpForce = 10f;
        
        private bool isGrounded;
        
        public DefaultLocomotionSystem(ILocomotionActor actor, ISpeedFactorProvider speedFactorProvider) 
            : base(actor, speedFactorProvider)
        {
        }

        public override void Update(UserInput input)
        {
            isGrounded = Actor.IsGrounded();

            Actor.Velocity = new Vector2(input.Horizontal * Speed * SpeedFactorProvider.SpeedFactor, Actor.Velocity.y);

            if (input.Jump)
            {
                Actor.Velocity = new Vector2(Actor.Velocity.x, JumpForce);
            }
        }
    }
}
