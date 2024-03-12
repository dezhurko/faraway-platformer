using System;
using Faraway.Pixel.Entities.Buffs;

namespace Faraway.Pixel.Entities.Interaction
{
    public class InteractiveObjectFactory
    {
        private readonly BuffCollection buffCollection;
        private readonly BuffFactory buffFactory;
        private readonly Player player;

        public InteractiveObjectFactory(BuffCollection buffCollection, BuffFactory buffFactory, Player player)
        {
            this.buffCollection = buffCollection;
            this.buffFactory = buffFactory;
            this.player = player;
        }

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