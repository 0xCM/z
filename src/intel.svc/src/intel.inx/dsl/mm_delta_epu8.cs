//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.dsl.intel
{
    [StructLayout(StructLayout,Pack=1)]
    public readonly struct mm_delta_epu8
    {
        public readonly __m128i<byte> A;

        public readonly __m128i<byte> B;

        [MethodImpl(Inline)]
        public mm_delta_epu8(in __m128i<byte> a, in __m128i<byte> b)
        {
            A = a;
            B = b;
        }

        public IntrinsicName Kind
            => IntrinsicName.mm_avg_epu8;
    }
}