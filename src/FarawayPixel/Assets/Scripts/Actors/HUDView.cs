using Faraway.Pixel.Actor.Contracts;
using TMPro;
using UnityEngine;

namespace Faraway.Pixel.Actors
{
    public class HUDView : MonoBehaviour, IHUDView
    {
        [SerializeField]
        private TMP_Text amountCollectedText;

        public void SetAmountCollectedText(string text)
        {
            amountCollectedText.text = text;
        }
    }
}