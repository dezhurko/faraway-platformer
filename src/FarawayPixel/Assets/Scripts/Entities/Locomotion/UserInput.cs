namespace Faraway.Pixel.Entities.Locomotion
{
    /// <summary>
    /// Represents the user input.
    /// </summary>
    public struct UserInput
    {
        /// <summary>
        /// Gets the horizontal input.
        /// </summary>
        public float Horizontal { get; }

        /// <summary>
        /// Gets the vertical input.
        /// </summary>
        public float Vertical { get; }

        /// <summary>
        /// Gets the jump input.
        /// </summary>
        public bool Jump { get; }
        
        public UserInput(float horizontal, float vertical, bool jump)
        {
            Horizontal = horizontal;
            Vertical = vertical;
            Jump = jump;
        }
    }
}