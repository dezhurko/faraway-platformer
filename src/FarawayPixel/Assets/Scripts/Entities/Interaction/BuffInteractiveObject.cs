using Faraway.Pixel.Entities.Buffs;

namespace Faraway.Pixel.Entities.Interaction
{
    /// <summary>
    /// Represents an interactive object that applies a buff to the player when interacted with.
    /// </summary>
    public class BuffInteractiveObject : InteractiveObject
    {
        private readonly BuffFactory buffFactory; 
        private readonly BuffCollection buffCollection;
        private readonly BuffInteractiveObjectData data;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BuffInteractiveObject"/> class.
        /// </summary>
        public BuffInteractiveObject(BuffFactory buffFactory, BuffCollection buffCollection, BuffInteractiveObjectData data)
        {
            this.buffFactory = buffFactory;
            this.buffCollection = buffCollection;
            this.data = data;
        }

        /// <inheritdoc/>
        public override void Interact()
        {
            var buff = buffFactory.CreateBuff(data.BuffData);
            buffCollection.AddBuff(buff);
        }
    }
}