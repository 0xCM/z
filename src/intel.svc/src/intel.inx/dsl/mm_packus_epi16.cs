//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.dsl.intel
{
    [StructLayout(StructLayout,Pack=1)]
    public struct mm_packus_epi16
    {
        public __m128i<short> A;

        public __m128i<short> B;

        [MethodImpl(Inline)]
        public mm_packus_epi16(in __m128i<short> a, in __m128i<short> b)
        {
            A = a;
            B = b;
        }

        public IntrinsicName Kind
            => IntrinsicName.mm_packus_epi16;
    }
}