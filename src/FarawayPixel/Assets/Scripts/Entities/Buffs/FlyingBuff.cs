using Faraway.Pixel.Entities.Locomotion;
using UnityEngine;

namespace Faraway.Pixel.Entities.Buffs
{
    public class FlyingBuff : Buff
    {
        private readonly ILocomotionActor locomotionActor;
        private readonly Player player;
        
        public FlyingBuff(FlyingBuffData data, ILocomotionActor locomotionActor, Player player) : base(data)
        {
            this.locomotionActor = locomotionActor;
            this.player = player;
        }
        
        public override void Apply(float time)
        {
            Debug.Log("Flying Buff: Set flying movement system as active.");
            
            base.Apply(time);
            var locomotion = new FlyingLocomotionSystem(locomotionActor, player);
            player.SetLocomotion(locomotion);
        }

        public override void Discard()
        {
            Debug.Log("Flying Buff: Reset movement system to default.");
            
            var locomotion = new DefaultLocomotionSystem(locomotionActor, player);
            player.SetLocomotion(locomotion);
        }
    }
}