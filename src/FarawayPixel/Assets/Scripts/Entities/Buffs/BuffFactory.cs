using System;
using Faraway.Pixel.Entities.Locomotion;

namespace Faraway.Pixel.Entities.Buffs
{
    /// <summary>
    /// Represents the factory for creating buffs.
    /// </summary>
    public class BuffFactory
    {
        private readonly Player player;
        private readonly ILocomotionActor locomotionActor;

        /// <summary>
        /// Initializes a new instance of the <see cref="BuffFactory"/> class.
        /// </summary>
        /// <param name="player">Player.</param>
        /// <param name="locomotionActor">Implementation of locomotion actor.</param>
        public BuffFactory(Player player, ILocomotionActor locomotionActor)
        {
            this.player = player;
            this.locomotionActor = locomotionActor;
        }

        /// <summary>
        /// Creates a buff from the given data.
        /// </summary>
        /// <param name="data">Buff data to create from.</param>
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