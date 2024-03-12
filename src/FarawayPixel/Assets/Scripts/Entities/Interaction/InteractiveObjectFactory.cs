using System;
using Faraway.Pixel.Entities.Buffs;

namespace Faraway.Pixel.Entities.Interaction
{
    /// <summary>
    /// Represents an interactive object factory for creating interactive objects based on their data..
    /// </summary>
    public class InteractiveObjectFactory
    {
        private readonly BuffCollection buffCollection;
        private readonly BuffFactory buffFactory;
        private readonly Player player;

        /// <summary>
        /// Initializes a new instance of the <see cref="InteractiveObjectFactory"/> class.
        /// </summary>
        public InteractiveObjectFactory(BuffCollection buffCollection, BuffFactory buffFactory, Player player)
        {
            this.buffCollection = buffCollection;
            this.buffFactory = buffFactory;
            this.player = player;
        }

        /// <summary>
        /// Creates an interactive object based on the data.
        /// </summary>
        public InteractiveObject CreateInteractiveObject(InteractiveObjectData data)
        {
            return data switch
            {
                BuffInteractiveObjectData buffInteractiveObjectData 
                    => new BuffInteractiveObject(buffFactory, buffCollection, buffInteractiveObjectData),
                CollectableObjectData collectableObjectData 
                    => new CollectableInteractiveObject(player, collectableObjectData),
                _ => throw new InvalidOperationException($"Can't create an interactive object for the data '{data.GetType()}'.")
            };
        }
    }
}