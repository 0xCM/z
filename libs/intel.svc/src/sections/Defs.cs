//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static intel;

    partial class IntelInx
    {
        public class Defs
        {
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

                public IntrinsicKind Kind
                    => IntrinsicKind.mm_ternarylogic_epi32;
            }

            [StructLayout(StructLayout,Pack=1)]
            public readonly struct mm256_cvtepi16_epi8
            {
                public readonly __m256i<ushort> A;

                [MethodImpl(Inline)]
                public mm256_cvtepi16_epi8(in __m256i<ushort> a)
                {
                    A = a;
                }

                public IntrinsicKind Kind
                    => IntrinsicKind._mm256_cvtepi16_epi8;
            }

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

                public IntrinsicKind Kind
                    => IntrinsicKind.mm_packus_epi16;
            }


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

                public IntrinsicKind Kind
                    => IntrinsicKind.mm_min_epi8;
            }

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

                public IntrinsicKind Kind
                    => IntrinsicKind.mm_blend_epi32;
            }

            [StructLayout(StructLayout,Pack=1)]
            public readonly struct mm_avg_epu8
            {
                public readonly __m128i<byte> A;

                public readonly __m128i<byte> B;

                [MethodImpl(Inline)]
                public mm_avg_epu8(in __m128i<byte> a, in __m128i<byte> b)
                {
                    A = a;
                    B = b;
                }

                public IntrinsicKind Kind
                    => IntrinsicKind.mm_avg_epu8;
            }

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

                public IntrinsicKind Kind
                    => IntrinsicKind.mm_avg_epu8;
            }

            [StructLayout(StructLayout,Pack=1)]
            public readonly struct mm256_min_epu8
            {
                public readonly __m256i<byte> A;

                public readonly __m256i<byte> B;

                [MethodImpl(Inline)]
                public mm256_min_epu8(in __m256i<byte> a, in __m256i<byte> b)
                {
                    A = a;
                    B = b;
                }

                public IntrinsicKind Kind
                    => IntrinsicKind.mm256_min_epu8;
            }
        }
    }
}