using System;
using UnityEngine;

namespace Faraway.Pixel.Entities.Buffs
{
    /// <summary>
    /// Base class for all buffs in the game.
    /// </summary>
    public abstract class Buff
    {
        /// <summary>
        /// Gets or sets the time when the buff ends.
        /// </summary>
        protected float EndTime { get; set; }
        
        /// <summary>
        /// Gets the duration of the buff.
        /// </summary>
        public float Duration { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="Buff"/> class.
        /// </summary>
        /// <param name="data">Buff data.</param>
        protected Buff(BuffData data)
        {
            Duration = data.Duration;
        }

        /// <summary>
        /// Applies the buff to the target.
        /// </summary>
        /// <param name="currentTime">Current time.</param>
        public virtual void Apply(float currentTime)
        {
            EndTime = currentTime + Duration;
        }

        /// <summary>
        /// Discards the buff.
        /// </summary>
        public abstract void Discard();

        /// <summary>
        /// Checks if the buff is stale.
        /// </summary>
        /// <param name="currentTime">Current time.</param>
        public bool IsStale(float currentTime) =>
            currentTime > EndTime;

        /// <summary>
        /// Checks if the buff is combinable with another buff.
        /// </summary>
        /// <param name="other">Another buff to combine.</param>
        public bool IsCombinable(Buff other) => other.GetType() == GetType();

        /// <summary>
        /// Combines the buff with another buff.
        /// </summary>
        /// <param name="other">Another buff to combine.</param>
        /// <param name="currentTime">Current time.</param>
        public virtual void Combine(Buff other, float currentTime)
        {
            if (!IsCombinable(other))
            {
                throw new InvalidOperationException("Can't combine buffs of different type.");
            }
            
            EndTime = Mathf.Max(EndTime, currentTime + other.Duration);
            
            Debug.Log($"Buff {other.GetType()} was combined with another active buff.");
        }
    }
}