using UnityEngine;

namespace Faraway.Pixel.Entities.Locomotion
{
    public class DefaultLocomotionSystem : LocomotionSystem
    {
        private const float Speed = 5f; 
        private const float JumpForce = 7f;
        
        public DefaultLocomotionSystem(ILocomotionActor actor, ISpeedFactorProvider speedFactorProvider) 
            : base(actor, speedFactorProvider)
        {
        }

        public override void Update(UserInput input)
        {
            Actor.Velocity = new Vector2(input.Horizontal * Speed * SpeedFactorProvider.SpeedFactor, Actor.Velocity.y);
            var isGrounded = Actor.IsGrounded();
            if (isGrounded && input.Jump)
            {
                Actor.Velocity = new Vector2(Actor.Velocity.x, JumpForce * SpeedFactorProvider.SpeedFactor);
            }
        }
    }
}
