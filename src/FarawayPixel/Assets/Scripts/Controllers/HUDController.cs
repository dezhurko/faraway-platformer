using Faraway.Pixel.Actors;
using Faraway.Pixel.Entities;

namespace Faraway.Pixel.Controllers
{
    public class HUDController
    {
        private HUDView view;
        private Player player;
        
        public HUDController(HUDView view, Player player)
        {
            this.view = view;
            this.player = player;

            UpdateView();
            player.ItemCollected += _ => UpdateView();
        }

        private void UpdateView()
        {
            view.SetAmountCollectedText($"{player.CollectedItemsCount}/{player.TotalItemsCount}");
        }
    }
}