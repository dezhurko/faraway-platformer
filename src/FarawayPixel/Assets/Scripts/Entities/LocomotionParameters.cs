namespace Faraway.Pixel.Entities
{
    public class LocomotionParameters
    {
        public const float DefaultSpeedFactor = 1f;
        
        private float speedFactor = DefaultSpeedFactor;

        public float SpeedFactor => speedFactor;
        
        public void ChangeSpeed(float factor)
        {
            speedFactor = factor;
        }

        public void ResetSpeed()
        {
            speedFactor = DefaultSpeedFactor;
        }
    }
}