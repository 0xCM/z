//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;

    public struct SymStore<T>
    {
        readonly Index<T> Data;

        uint k;

        public readonly uint Segment;

        internal SymStore(uint seg, T[] buffer)
        {
            Segment = seg;
            Data = buffer;
            k = 0;
        }

        public ReadOnlySpan<T> Deposited
        {
            [MethodImpl(Inline)]
            get => slice(Data.View,0,k);
        }

        public ushort Capacity
        {
            [MethodImpl(Inline)]
            get => (ushort)Data.Count;
        }

        [MethodImpl(Inline)]
        public ref readonly T Find(in SymRef src)
            => ref Data[src.Key];

        [MethodImpl(Inline)]
        public bool Deposit(in T src, out SymRef dst)
        {
            if(k < Capacity - 1)
            {
                Data[k] = src;
                dst = new SymRef((ushort)Segment, (ushort)k);
                k++;
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }
    }
}