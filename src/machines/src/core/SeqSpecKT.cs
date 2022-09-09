//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a T-valued sequence over a K-indexed interval
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="T"></typeparam>
    public abstract class SeqSpec<K,T>
        where T : unmanaged
        where K : unmanaged
    {
        public ulong Compute(Action<K,T> dst)
        {
            var counter=0ul;
            var j = default(K);
            var @continue = false;
            for(;;)
            {
                 @continue = Next(ref j, out var t);
                 dst(j, t);
                 counter++;
                 if(!@continue)
                    break;
            }
            return counter;
        }

        protected abstract bool Next(ref K k, out T dst);
    }
}