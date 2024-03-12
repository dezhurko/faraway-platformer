namespace Faraway.Pixel.Entities
{
    /// <summary>
    /// Represents the locomotion parameters.
    /// </summary>
    public class LocomotionParameters
    {
        /// <summary>
        /// Gets the default speed factor.
        /// </summary>
        public const float DefaultSpeedFactor = 1f;
        
        private float speedFactor = DefaultSpeedFactor;

        /// <summary>
        /// Gets the speed factor.
        /// </summary>
        public float SpeedFactor => speedFactor;
        
        /// <summary>
        /// Changes the speed factor.
        /// </summary>
        public void SetSpeed(float factor)
        {
            speedFactor = factor;
        }

        /// <summary>
        /// Resets the speed factor to the default value.
        /// </summary>
        public void ResetSpeed()
        {
            speedFactor = DefaultSpeedFactor;
        }
    }
}