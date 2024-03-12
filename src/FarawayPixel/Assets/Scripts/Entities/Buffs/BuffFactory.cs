using System;
using Faraway.Pixel.Entities.Locomotion;

namespace Faraway.Pixel.Entities.Buffs
{
    public class BuffFactory
    {
        private readonly Player player;
        private readonly ILocomotionActor locomotionActor;

        public BuffFactory(Player player, ILocomotionActor locomotionActor)
        {
            this.player = player;
            this.locomotionActor = locomotionActor;
        }

        public Buff CreateBuff(BuffData data)
        {
            return data switch
            {
                SpeedBuffData  speedBuffData => new SpeedBuff(speedBuffData, player.LocomotionParameters),
                FlyingBuffData  flyingBuffData => new FlyingBuff(flyingBuffData, locomotionActor, player),
                _ => throw new InvalidOperationException($"Can't create Buff for the data '{data.GetType()}'.")
            };
        }
    }
}