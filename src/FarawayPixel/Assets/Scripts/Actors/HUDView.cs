using Faraway.Pixel.Actor.Contracts;
using TMPro;
using UnityEngine;

namespace Faraway.Pixel.Actors
{
    /// <summary>
    /// Represents the heads-up display (HUD) view in the game.
    /// </summary>
    public class HUDView : MonoBehaviour, IHUDView
    {
        [SerializeField]
        private TMP_Text amountCollectedText;

        /// <inheritdoc/>
        public void SetAmountCollectedText(string text)
        {
            amountCollectedText.text = text;
        }
    }
}