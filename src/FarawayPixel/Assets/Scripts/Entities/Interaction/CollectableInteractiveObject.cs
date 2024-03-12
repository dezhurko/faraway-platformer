namespace Faraway.Pixel.Entities.Interaction
{
    /// <summary>
    /// Represents a collectable interactive object.
    /// </summary>
    public class CollectableInteractiveObject : InteractiveObject
    {
        private readonly Player player;
        private readonly CollectableObjectData data;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectableInteractiveObject"/> class.
        /// </summary>
        public CollectableInteractiveObject(Player player, CollectableObjectData data)
        {
            this.player = player;
            this.data = data;
        }

        /// <inheritdoc/>
        public override void Interact()
        {
            player.CollectItem(data.Amount);
        }
    }
}