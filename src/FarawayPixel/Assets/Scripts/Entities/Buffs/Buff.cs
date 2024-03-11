using System;
using UnityEngine;

namespace Faraway.Pixel.Entities.Buffs
{
    public abstract class Buff
    {
        protected float EndTime { get; set; }
        
        public float Duration { get; }

        protected Buff(BuffData data)
        {
            Duration = data.Duration;
        }

        public virtual void Apply(float currentTime)
        {
            EndTime = currentTime + Duration;
        }

        public abstract void Discard();

        public bool IsStale(float currentTime) =>
            currentTime > EndTime;

        public bool IsCombinable(Buff other) => other.GetType() == GetType();

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