namespace Faraway.Pixel.Entities.Locomotion
{
    public abstract class LocomotionSystem
    {
        protected ILocomotionActor Actor { get; }
        
        protected LocomotionParameters LocomotionParameters { get; }

        public abstract LocomotionActorState ActorState { get; }

        protected LocomotionSystem(ILocomotionActor actor, LocomotionParameters locomotionParameters)
        { 
            Actor = actor;
            LocomotionParameters = locomotionParameters;
        }

        public abstract void Update(UserInput input);
    }
}