using System;
using UnityEngine;

namespace Faraway.Pixel.Entities.Buffs
{
    /// <summary>
    /// Represents a speed buff.
    /// </summary>
    public class SpeedBuff : Buff
    {
        private readonly LocomotionParameters locomotionParameters;
        
        private float speedFactor;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SpeedBuff"/> class.
        /// </summary>
        public SpeedBuff(SpeedBuffData data, LocomotionParameters locomotionParameters) : base(data)
        {
            speedFactor = data.SpeedChangeFactor;
            this.locomotionParameters = locomotionParameters;
        }
        
        /// <inheritdoc/>
        public override void Apply(float time)
        {
            Debug.Log($"Speed Buff: Changing player speed to {speedFactor}.");
            
            base.Apply(time);
            locomotionParameters.SetSpeed(speedFactor);
        }

        /// <inheritdoc/>
        public override void Discard()
        {
            Debug.Log("Speed Buff: Resetting player speed.");
            
            locomotionParameters.ResetSpeed();
        }

        /// <inheritdoc/>
        public override void Combine(Buff other, float currentTime)
        {
            if (!IsCombinable(other))
            {
                throw new InvalidOperationException("Can't combine buffs of different type.");
            }
            
            EndTime = currentTime + other.Duration;
            speedFactor = ((SpeedBuff)other).speedFactor;
            locomotionParameters.SetSpeed(speedFactor);
            
            Debug.Log($"Buff {other.GetType()} was combined with another active buff. " +
                      $"Speed factor {speedFactor}, end time: {EndTime}");
        }
    }
}