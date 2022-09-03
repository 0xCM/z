//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class PairedLookup<L,R>
    {
        readonly Dictionary<L,R> LR;

        readonly Dictionary<R,L> RL;

        public PairedLookup()
        {
            LR = new();
            RL = new();
        }

        public PairedLookup(Dictionary<L,R> lr)
        {
            LR = lr;
            RL = new();

            foreach(var k in lr.Keys)
                RL[lr[k]] = k;
        }

        public PairedLookup(Dictionary<R,L> rl)
        {
            LR = new();
            RL = rl;
            foreach(var k in rl.Keys)
                LR[rl[k]] = k;
        }

        public PairedLookup(Dictionary<L,R> lr, Dictionary<R,L> rl)
        {
            LR = lr;
            RL = rl;
            foreach(var k in rl.Keys)
                LR[rl[k]] = k;
        }

        public R this[L key]
        {
            [MethodImpl(Inline)]
            get => LR[key];

            [MethodImpl(Inline)]
            set
            {
                LR[key] = value;
                RL[value] = key;
            }
        }

        public L this[R key]
        {
            [MethodImpl(Inline)]
            get => RL[key];

            [MethodImpl(Inline)]
            set
            {
                LR[value] = key;
                RL[key] = value;
            }
        }

        public void Include(Dictionary<L,R> src)
        {
            foreach(var k in src.Keys)
                this[k] = src[k];
        }

        public void Include(Dictionary<R,L> src)
        {
            foreach(var k in src.Keys)
                this[k] = src[k];
        }

        public ICollection<L> LeftValues
        {
            [MethodImpl(Inline)]
            get => LR.Keys;
        }

        public ICollection<R> RightValues
        {
            [MethodImpl(Inline)]
            get => RL.Keys;
        }
    }
}