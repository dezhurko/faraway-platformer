namespace Faraway.Pixel.Entities.Locomotion
{
    public abstract class LocomotionSystem
    {
        protected ILocomotionActor Actor { get; }
        
        protected ISpeedFactorProvider SpeedFactorProvider { get; }

        protected LocomotionSystem(ILocomotionActor actor, ISpeedFactorProvider speedFactorProvider)
        { 
            Actor = actor;
            SpeedFactorProvider = speedFactorProvider;
        }

        public abstract void Update(UserInput input);
    }
}