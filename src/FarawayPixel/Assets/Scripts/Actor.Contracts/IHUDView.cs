namespace Faraway.Pixel.Actor.Contracts
{
    /// <summary>
    /// Represents interface for the hud view.
    /// </summary>
    public interface IHUDView
    {
        /// <summary>
        /// Sets the text for displaying the amount of collected items.
        /// </summary>
        /// <param name="text">The text to be displayed.</param>
        void SetAmountCollectedText(string text);
    }
}