//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.dsl.intel
{
    [StructLayout(StructLayout,Pack=1)]
    public readonly struct mm_blend_epi32
    {
        public readonly __m128i<uint> A;

        public readonly __m128i<uint> B;

        public readonly Imm8 Imm8;

        [MethodImpl(Inline)]
        public mm_blend_epi32(in __m128i<uint> a, in __m128i<uint> b, Imm8 imm8)
        {
            A = a;
            B = b;
            Imm8 = imm8;
        }

        public IntrinsicName Kind
            => IntrinsicName.mm_blend_epi32;
    }
}