namespace Faraway.Pixel.Actor.Contracts
{
    public interface IPlayerAnimator
    {
        void PlayRunAnimation();
        void PlayIdleAnimation();
        void PlayFlyAnimation();
        void FlipHorizontal(bool flip);
    }
}