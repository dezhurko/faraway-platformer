using System.Collections.Generic;
using UnityEngine.Pool;

namespace Faraway.Pixel.Entities.Buffs
{
    public class BuffCollection
    {
        private readonly List<Buff> activeBuffs = new ();
        private readonly ITimeProvider timeProvider;

        public IReadOnlyList<Buff> ActiveBuffs => activeBuffs;

        public BuffCollection(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider;
        }

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