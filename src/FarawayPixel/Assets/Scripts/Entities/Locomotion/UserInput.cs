namespace Faraway.Pixel.Entities.Locomotion
{
    public struct UserInput
    {
        public float Horizontal { get; }

        public float Vertical { get; }

        public bool Jump { get; }

        public float DeltaTime { get; }
        
        public UserInput(float horizontal, float vertical, bool jump, float deltaTime)
        {
            Horizontal = horizontal;
            Vertical = vertical;
            Jump = jump;
            DeltaTime = deltaTime;
        }
    }
}