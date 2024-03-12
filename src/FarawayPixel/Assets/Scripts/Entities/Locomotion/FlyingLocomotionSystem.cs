using UnityEngine;

namespace Faraway.Pixel.Entities.Locomotion
{
    public class FlyingLocomotionSystem : LocomotionSystem
    {
        private const float Speed = 5f; 
        
        private bool isGrounded;
        private float moveDirection;
        
        public override LocomotionActorState ActorState => LocomotionActorState.Fly;
        
        public FlyingLocomotionSystem(ILocomotionActor actor, LocomotionParameters locomotionParameters) 
            : base(actor, locomotionParameters)
        {
        }

        public override void Update(UserInput input)
        {
            if (Mathf.Abs(input.Horizontal) > Mathf.Epsilon)
            {
                moveDirection = Mathf.Sign(input.Horizontal);
            }

            Actor.Velocity = new Vector2(
                moveDirection * Speed * LocomotionParameters.SpeedFactor, 
                input.Vertical * Speed * LocomotionParameters.SpeedFactor);
        }
    }
}