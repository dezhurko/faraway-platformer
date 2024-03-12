using System;
using UnityEngine;

namespace Faraway.Pixel.Entities.Buffs
{
    public class SpeedBuff : Buff
    {
        private readonly LocomotionParameters locomotionParameters;
        
        private float speedFactor;
        
        public SpeedBuff(SpeedBuffData data, LocomotionParameters locomotionParameters) : base(data)
        {
            speedFactor = data.SpeedChangeFactor;
            this.locomotionParameters = locomotionParameters;
        }
        
        public override void Apply(float time)
        {
            Debug.Log($"Speed Buff: Changing player speed to {speedFactor}.");
            
            base.Apply(time);
            locomotionParameters.ChangeSpeed(speedFactor);
        }

        public override void Discard()
        {
            Debug.Log("Speed Buff: Resetting player speed.");
            
            locomotionParameters.ResetSpeed();
        }

        public override void Combine(Buff other, float currentTime)
        {
            if (!IsCombinable(other))
            {
                throw new InvalidOperationException("Can't combine buffs of different type.");
            }
            
            EndTime = currentTime + other.Duration;
            speedFactor = ((SpeedBuff)other).speedFactor;
            locomotionParameters.ChangeSpeed(speedFactor);
            
            Debug.Log($"Buff {other.GetType()} was combined with another active buff. " +
                      $"Speed factor {speedFactor}, end time: {EndTime}");
        }
    }
}