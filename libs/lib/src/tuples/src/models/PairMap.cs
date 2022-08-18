//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class PairMap<I,K>
    {
        public readonly Pairings<I,K> Left;

        public readonly Pairings<K,I> Right;

        public readonly uint Count;

        [MethodImpl(Inline)]
        public PairMap(uint count, Paired<I,K>[] left, Paired<K,I>[] right)
        {
            Count = count;
            Left = left;
            Right = right;
        }

        [MethodImpl(Inline)]
        public ref Paired<I,K> LeftPair(int i)
            => ref Left[i];

        [MethodImpl(Inline)]
        public ref Paired<K,I> RightPair(int i)
            => ref Right[i];

        [MethodImpl(Inline)]
        public ref Paired<I,K> LeftPair(uint i)
            => ref Left[i];

        [MethodImpl(Inline)]
        public ref Paired<K,I> RightPair(uint i)
            => ref Right[i];
    }
}