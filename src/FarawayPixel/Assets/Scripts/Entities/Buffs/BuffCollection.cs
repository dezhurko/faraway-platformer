using System.Collections.Generic;
using UnityEngine.Pool;

namespace Faraway.Pixel.Entities.Buffs
{
    /// <summary>
    /// Represents a collection of active buffs.
    /// </summary>
    public class BuffCollection
    {
        private readonly List<Buff> activeBuffs = new ();
        private readonly ITimeProvider timeProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="BuffCollection"/> class.
        /// </summary>
        /// <param name="timeProvider">Time provider.</param>
        public BuffCollection(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider;
        }

        /// <summary>
        /// Adds a buff to the collection.
        /// </summary>
        /// <param name="buff">Buff to add.</param>
        public void AddBuff(Buff buff)
        {
            var wasCombined = false;
            foreach (var activeBuff in activeBuffs)
            {
                if (activeBuff.IsCombinable(buff))
                {
                    activeBuff.Combine(buff, timeProvider.Now);
                    wasCombined = true;
                    break;
                }
            }

            if (!wasCombined)
            {
                buff.Apply(timeProvider.Now);
                activeBuffs.Add(buff);
            }
        }
        
        /// <summary>
        /// Updates the collection. Must be executed in the game loop.
        /// </summary>
        public void Update()
        {
            var staleBuffs = ListPool<Buff>.Get();
            foreach (var buff in activeBuffs)
            {
                if (buff.IsStale(timeProvider.Now))
                {
                    staleBuffs.Add(buff);
                }
            }

            foreach (var staledBuff in staleBuffs)
            {
                staledBuff.Discard();
                activeBuffs.Remove(staledBuff);
            }
            
            ListPool<Buff>.Release(staleBuffs);
        }
    }
}