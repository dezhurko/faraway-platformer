using Faraway.Pixel.Actor.Contracts;
using Faraway.Pixel.Entities;

namespace Faraway.Pixel.Controllers
{
    /// <summary>
    /// Represents an interactive object that grants a speed buff to the player upon interaction.
    /// </summary>
    public class HUDController
    {
        private readonly IHUDView view;
        private readonly Player player;
        
        /// <summary>
        /// Constructor for the HUDController.
        /// </summary>
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