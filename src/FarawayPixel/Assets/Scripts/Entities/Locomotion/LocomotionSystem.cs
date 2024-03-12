namespace Faraway.Pixel.Entities.Locomotion
{
    /// <summary>
    /// Represents the base class for a locomotion system.
    /// </summary>
    public abstract class LocomotionSystem
    {
        /// <summary>
        /// Gets the locomotion actor.
        /// </summary>
        protected ILocomotionActor Actor { get; }
        
        /// <summary>
        /// Gets the locomotion parameters.
        /// </summary>
        protected LocomotionParameters LocomotionParameters { get; }

        /// <summary>
        /// Gets the locomotion actor state.
        /// </summary>
        public abstract LocomotionActorState ActorState { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocomotionSystem"/> class.
        /// </summary>
        protected LocomotionSystem(ILocomotionActor actor, LocomotionParameters locomotionParameters)
        { 
            Actor = actor;
            LocomotionParameters = locomotionParameters;
        }

        /// <summary>
        /// Updates the locomotion system. Must be called every frame.
        /// </summary>
        public abstract void Update(UserInput input);
    }
}