namespace Faraway.Pixel.Entities.Interaction
{
    public class CollectableInteractiveObject : InteractiveObject
    {
        private readonly Player player;
        private readonly CollectableObjectData data;

        public CollectableInteractiveObject(Player player, CollectableObjectData data)
        {
            this.player = player;
            this.data = data;
        }

        public override void Interact()
        {
            player.CollectItem(data.Amount);
        }
    }
}