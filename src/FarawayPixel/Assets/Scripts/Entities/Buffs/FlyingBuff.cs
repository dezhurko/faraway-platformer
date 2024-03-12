using Faraway.Pixel.Entities.Locomotion;
using UnityEngine;

namespace Faraway.Pixel.Entities.Buffs
{
    /// <summary>
    /// Represents a buff that allows the player to fly.
    /// </summary>
    public class FlyingBuff : Buff
    {
        private readonly ILocomotionActor locomotionActor;
        private readonly Player player;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="FlyingBuff"/> class.
        /// </summary>
        public FlyingBuff(FlyingBuffData data, ILocomotionActor locomotionActor, Player player) : base(data)
        {
            this.locomotionActor = locomotionActor;
            this.player = player;
        }
        
        /// <inheritdoc/>
        public override void Apply(float time)
        {
            Debug.Log("Flying Buff: Set flying movement system as active.");
            
            base.Apply(time);
            var locomotion = new FlyingLocomotionSystem(locomotionActor, player.LocomotionParameters);
            player.SetLocomotion(locomotion);
        }

        /// <inheritdoc/>
        public override void Discard()
        {
            Debug.Log("Flying Buff: Reset movement system to default.");
            
            var locomotion = new DefaultLocomotionSystem(locomotionActor, player.LocomotionParameters);
            player.SetLocomotion(locomotion);
        }
    }
}