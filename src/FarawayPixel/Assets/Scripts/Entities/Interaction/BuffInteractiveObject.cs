using Faraway.Pixel.Entities.Buffs;

namespace Faraway.Pixel.Entities.Interaction
{
    public class BuffInteractiveObject : InteractiveObject
    {
        private readonly BuffFactory buffFactory; 
        private readonly BuffCollection buffCollection;
        private readonly BuffInteractiveObjectData data;
        
        public BuffInteractiveObject(BuffFactory buffFactory, BuffCollection buffCollection, BuffInteractiveObjectData data)
        {
            this.buffFactory = buffFactory;
            this.buffCollection = buffCollection;
            this.data = data;
        }

        public override void Interact()
        {
            var buff = buffFactory.CreateBuff(data.BuffData);
            buffCollection.AddBuff(buff);
        }
    }
}