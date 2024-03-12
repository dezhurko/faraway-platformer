using TMPro;
using UnityEngine;

namespace Faraway.Pixel.Actors
{
    public class HUDView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text amountCollectedText;

        public void SetAmountCollectedText(string text)
        {
            amountCollectedText.text = text;
        }
    }
}