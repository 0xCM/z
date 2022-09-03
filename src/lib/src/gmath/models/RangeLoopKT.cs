//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct RangeLoop<K,T>
        where K : unmanaged
    {
        public readonly K Min;

        public readonly K Max;

        public readonly K Step;

        public readonly Action<K,T> Receiver;

        [MethodImpl(Inline)]
        public RangeLoop(K min, K max, K step, Action<K,T> receiver)
        {
            Min = min;
            Max = max;
            Step = step;
            Receiver = receiver;
        }
    }
}