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
        public ulong Compute(Action<K,T> receiver)
        {
            var counter=0ul;
            var j = default(K);
            var @continue = false;
            for(;;)
            {
                 @continue = Next(ref j, out var t);
                 receiver(j, t);
                 counter++;
                 if(!@continue)
                    break;
            }
            return counter;
        }

        protected abstract bool Next(ref K k, out T dst);
    }

    public readonly partial struct SeqSpecs
    {
        public static FiniteSeq32u finite(Interval<uint> limits, Func<uint,uint> rule)
            => new FiniteSeq32u(limits,rule);

        public sealed class FiniteSeq32u : SeqSpec<uint, uint>
        {
            public Interval<uint> Limits;

            public uint Min {get;}

            public uint Max {get;}

            readonly Func<uint,uint> Rule;

            public FiniteSeq32u(Interval<uint> limits, Func<uint,uint> rule)
            {
                Limits = limits;
                Min = Limits.LeftClosed ? Limits.Left : Limits.Left + 1;
                Max = Limits.RightClosed ? Limits.Right : Limits.Right - 1u;
                Rule = rule;
            }

            protected override bool Next(ref uint k, out uint dst)
            {
                dst = Rule(k++);
                return k < Max;
            }
        }
    }
}