using UnityEngine;

namespace Faraway.Pixel.Entities.Locomotion
{
    public class DefaultLocomotionSystem : LocomotionSystem
    {
        private const float Speed = 5f; 
        private const float JumpForce = 7f;
        
        public override LocomotionActorState ActorState =>
            Mathf.Abs(Actor.Velocity.x) > Mathf.Epsilon
                ? LocomotionActorState.Run
                : LocomotionActorState.Idle;
        
        public DefaultLocomotionSystem(ILocomotionActor actor, LocomotionParameters locomotionParameters) 
            : base(actor, locomotionParameters)
        {
        }

        public override void Update(UserInput input)
        {
            Actor.Velocity = new Vector2(input.Horizontal * Speed * LocomotionParameters.SpeedFactor, Actor.Velocity.y);
            var isGrounded = Actor.IsGrounded();
            if (isGrounded && input.Jump)
            {
                Actor.Velocity = new Vector2(Actor.Velocity.x, JumpForce * LocomotionParameters.SpeedFactor);
            }
        }
    }
}
