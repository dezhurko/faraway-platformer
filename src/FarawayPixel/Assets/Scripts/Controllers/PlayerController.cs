using Faraway.Pixel.Actors;
using Faraway.Pixel.Entities;

namespace Faraway.Pixel.Controllers
{
    public class PlayerController
    {
        private readonly PlayerActor playerActor;
        private readonly Player player;
        private readonly IInputProvider inputProvider;

        public PlayerController(PlayerActor playerActor, Player player, IInputProvider inputProvider)
        {
            this.playerActor = playerActor;
            this.player = player;
            this.inputProvider = inputProvider;
        }

        public void Update()
        {
            var input = inputProvider.GetInput();
            player.Locomotion.Update(input);
            playerActor.FlipHorizontal(playerActor.Velocity.x < 0);
        }
    }
}