namespace Faraway.Pixel.Actor.Contracts
{
    /// <summary>
    /// Represents interface for playing avatar animations.
    /// </summary>
    public interface IPlayerAnimator
    {
        /// <summary>
        /// Play run animation.
        /// </summary>
        void PlayRunAnimation();
        
        /// <summary>
        /// Play idle animation.
        /// </summary>
        void PlayIdleAnimation();
        
        /// <summary>
        /// Play fly animation.
        /// </summary>
        void PlayFlyAnimation();
        
        /// <summary>
        /// Flip animation sprite horizontal.
        /// </summary>
        /// <param name="flip">If true the animation sprite will be flipped</param>
        void FlipHorizontal(bool flip);
    }
}