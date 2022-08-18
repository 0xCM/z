//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;
    using static Refs;
    using static Arrays;

    public class PairMap<T>
    {
        public readonly Pairs<T> Values;

        public readonly uint Count;

        public PairMap(T[] left, T[] right)
        {
            Count = Require.equal((uint)left.Length, (uint)right.Length);
            Values = core.mapi(left, (i,x) => core.pair(x,skip(right,i)));
        }

        public ref Pair<T> this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Values[i];
        }

        [MethodImpl(Inline)]
        public ref T Left(uint i)
            => ref this[i].Left;

        [MethodImpl(Inline)]
        public ref T Right(uint i)
            => ref this[i].Left;

        public ref Pair<T> this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Values[i];
        }

        [MethodImpl(Inline)]
        public ref T Left(int i)
            => ref this[i].Left;

        [MethodImpl(Inline)]
        public ref T Right(int i)
            => ref this[i].Left;
    }
}