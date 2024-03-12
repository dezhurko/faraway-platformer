using Faraway.Pixel.Actor.Contracts;
using Faraway.Pixel.Entities;

namespace Faraway.Pixel.Controllers
{
    public class HUDController
    {
        private readonly IHUDView view;
        private readonly Player player;
        
        public HUDController(IHUDView view, Player player)
        {
            this.view = view;
            this.player = player;

            UpdateView();
            player.ItemCollected += _ => UpdateView();
        }

        private void UpdateView()
        {
            view.SetAmountCollectedText($"{player.CollectedItemsCount}|{player.TotalItemsCount}");
        }
    }
}