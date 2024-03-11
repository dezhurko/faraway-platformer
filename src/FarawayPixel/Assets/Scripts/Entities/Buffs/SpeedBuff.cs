using System;
using UnityEngine;

namespace Faraway.Pixel.Entities.Buffs
{
    public class SpeedBuff : Buff
    {
        private readonly Player player;
        
        private float speedFactor;
        
        public SpeedBuff(SpeedBuffData data, Player player) : base(data)
        {
            speedFactor = data.SpeedChangeFactor;
            this.player = player;
        }
        
        public override void Apply(float time)
        {
            Debug.Log($"Speed Buff: Changing player speed to {speedFactor}.");
            
            base.Apply(time);
            player.ChangeSpeed(speedFactor);
        }

        public override void Discard()
        {
            Debug.Log("Speed Buff: Resetting player speed.");
            
            player.ResetSpeed();
        }

        public override void Combine(Buff other, float currentTime)
        {
            if (!IsCombinable(other))
            {
                throw new InvalidOperationException("Can't combine buffs of different type.");
            }
            
            EndTime = currentTime + other.Duration;
            speedFactor = ((SpeedBuff)other).speedFactor;
            player.ChangeSpeed(speedFactor);
            
            Debug.Log($"Buff {other.GetType()} was combined with another active buff. " +
                      $"Speed factor {speedFactor}, end time: {EndTime}");
        }
    }
}