using System;
using Faraway.Pixel.Entities.Buffs;

namespace Faraway.Pixel.Entities.Interaction
{
    public class InteractiveObjectFactory
    {
        private readonly BuffCollection buffCollection;
        private readonly BuffFactory buffFactory;

        public InteractiveObjectFactory(BuffCollection buffCollection, BuffFactory buffFactory)
        {
            this.buffCollection = buffCollection;
            this.buffFactory = buffFactory;
        }

        public InteractiveObject CreateInteractiveObject(InteractiveObjectData data)
        {
            return data switch
            {
                BuffInteractiveObjectData buffInteractiveObjectData 
                    => new BuffInteractiveObject(buffFactory, buffCollection, buffInteractiveObjectData),
                _ => throw new InvalidOperationException($"Can't create an interactive object for the data '{data.GetType()}'.")
            };
        }
    }
}