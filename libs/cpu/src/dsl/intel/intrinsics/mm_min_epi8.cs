//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.dsl.intel
{
    [StructLayout(StructLayout,Pack=1)]
    public readonly struct mm_min_epi8
    {
        public readonly __m128i<sbyte> A;

        public readonly __m128i<sbyte> B;

        [MethodImpl(Inline)]
        public mm_min_epi8(in __m128i<sbyte> a, in __m128i<sbyte> b)
        {
            A = a;
            B = b;
        }

        public IntrinsicName Kind
            => IntrinsicName.mm_min_epi8;
    }
}