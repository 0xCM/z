//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.dsl.intel
{
    using Asm;

    [StructLayout(StructLayout,Pack=1)]
    public struct mm_ternarylogic_epi32
    {
        public __m128i<uint> A;

        public __m128i<uint> B;

        public __m128i<uint> C;

        public Imm8 Imm8;

        [MethodImpl(Inline)]
        public mm_ternarylogic_epi32(__m128i<uint> a, __m128i<uint> b, __m128i<uint> c, Imm8 imm8)
        {
            A = a;
            B = b;
            C = c;
            Imm8 = imm8;
        }

        public IntrinsicName Kind
            => IntrinsicName.mm_ternarylogic_epi32;
    }
}