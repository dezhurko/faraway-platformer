using UnityEngine;

namespace Faraway.Pixel.Entities.Locomotion
{
    /// <summary>
    /// Represents the flying locomotion system.
    /// </summary>
    public class FlyingLocomotionSystem : LocomotionSystem
    {
        private const float Speed = 5f; 
        
        private bool isGrounded;
        private float moveDirection;
        
        /// <inheritdoc/>
        public override LocomotionActorState ActorState => LocomotionActorState.Fly;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="FlyingLocomotionSystem"/> class.
        /// </summary>
        public FlyingLocomotionSystem(ILocomotionActor actor, LocomotionParameters locomotionParameters) 
            : base(actor, locomotionParameters)
        {
        }

        /// <inheritdoc/>
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