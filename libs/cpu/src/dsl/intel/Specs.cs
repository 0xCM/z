//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.dsl.intel
{
    using Expr;

    using static math;
    using static BitNumbers;

    [ApiHost]
    public class Specs
    {
        [MethodImpl(Inline), Op]
        public static byte trunc8(ushort src)
            => (byte)src;

        [MethodImpl(Inline), Op]
        public static uint mm256_cvtepi16_epi8_loop(Span<v3<int>> dst)
        {
            var counter = 0u;
            for(var j=0; j<=15; j++)
            {
                var i=16*j;
                var l=8*j;
                core.seek(dst,j) = expr.v(j, i, l);
                counter++;
            }
            return counter;
        }

        [MethodImpl(Inline), Op]
        public static uint _mm256_cvtepi16_epi8_seq(ReadOnlySpan<__m256i<ushort>> src, Span<__m128i<byte>> dst)
        {
            var count = (uint)src.Length;
            for(var i=0; i<count; i++)
                core.seek(dst,i) = Specs.mm256_cvtepi16_epi8(core.skip(src,i));
            return count;
        }

        [MethodImpl(Inline), Op]
        public static __m128i<uint> calc(in mm_ternarylogic_epi32 src)
            => Specs.mm_ternarylogic_epi32(src.A, src.B, src.C, src.Imm8);

        /// <summary>
        /// __m128i _mm_ternarylogic_epi32(__m128i a, __m128i b, __m128i c, int imm8)
        /// VPTERNLOGD xmm, xmm, xmm, imm8
        /// Bitwise ternary logic that provides the capability to implement any three-operand binary function;
        /// the specific binary function is specified by value in "imm8". For each bit in each packed 32-bit integer,
        /// the corresponding bit from "a", "b", and "c" are used to form a 3 bit index into "imm8", and the value at
        /// that bit in "imm8" is written to the corresponding bit in "dst".
        /// </summary>
        [MethodImpl(Inline), Op]
        public static __m128i<uint> mm_ternarylogic_epi32(__m128i<uint> a, __m128i<uint> b, __m128i<uint> c, Imm8 imm8)
        {
            var dst = intel.m128i<uint>();
            for(byte j=0; j<=3; j++)
            {
                var i = j*32;
                for(byte h=0; h<=31; h++)
                {
                    var index = join(c[i+h], b[i+h], a[i+h]);
                    dst[i + h] = imm8[index];
                }
            }
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static __m128i<byte> calc(in mm256_cvtepi16_epi8 src)
            => Specs.mm256_cvtepi16_epi8(src.A);

        [MethodImpl(Inline), Op]
        public static __m128i<byte> mm256_cvtepi16_epi8(__m256i<ushort> a)
        {
            var dst = intel.m128i<byte>();
            for(var j=0; j<=15; j++)
            {
                var i=16*j;
                var l=8*j;
                dst[l+7,l] = trunc8(a[i+15,i]);
            }

            return dst;
        }

        [MethodImpl(Inline), Op]
        public static __m128i<byte> calc(in mm_packus_epi16 io)
            => Specs.mm_packus_epi16(io.A, io.B);

        [MethodImpl(Inline), Op]
        public static __m128i<byte> mm_packus_epi16(in __m128i<short> a, in __m128i<short> b)
        {
            var dst = intel.m128i<byte>();
            dst[7,0] = sat8u(a[15,0]);
            dst[15,8] = sat8u(a[31,16]);
            dst[23,16] = sat8u(a[47,32]);
            dst[31,24] = sat8u(a[63,48]);
            dst[39,32] = sat8u(a[79,64]);
            dst[47,40] = sat8u(a[95,80]);
            dst[55,48] = sat8u(a[111,96]);
            dst[63,56] = sat8u(a[127,112]);
            dst[71,64] = sat8u(b[15,0]);
            dst[79,72] = sat8u(b[31,16]);
            dst[87,80] = sat8u(b[47,32]);
            dst[95,88] = sat8u(b[63,48]);
            dst[103,96] = sat8u(b[79,64]);
            dst[111,104] = sat8u(b[95,80]);
            dst[119,112] = sat8u(b[111,96]);
            dst[127,120] = sat8u(b[127,112]);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static __m128i<sbyte> calc(in mm_min_epi8 src)
            => mm_min_epi8(src.A, src.B);

        [MethodImpl(Inline), Op]
        public static __m128i<sbyte> mm_min_epi8(in __m128i<sbyte> a, in __m128i<sbyte> b)
        {
            var dst = intel.m128i<sbyte>();
            for(var j=0; j<=15; j++)
            {
                var i = j*8;
                dst[i+7,i] = math.min(a[i+7,i], b[i+7,i]);
            }
            return dst;
        }

        [MethodImpl(Inline)]
        public static __m128i<uint> calc(in mm_blend_epi32 src)
            => Specs.mm_blend_epi32(src.A, src.B, src.Imm8);

        [MethodImpl(Inline)]
        public static __m128i<uint> mm_blend_epi32(in __m128i<uint> a, in __m128i<uint> b, Imm8 imm8)
        {
            var dst = intel.m128i<uint>();
            var i=0;
            for(var j=0; j<=3; j++)
            {
                i = j*32;
                if(imm8[i])
                    dst[i+31,i] = b[i+31,i];
                else
                    dst[i+31,i] = a[i+31,i];
            }

            return dst;
        }

        [MethodImpl(Inline)]
        public static __m128i<byte> calc(in mm_avg_epu8 src)
            => mm_avg_epu8(src.A, src.B);

        [MethodImpl(Inline)]
        public static __m128i<byte> mm_avg_epu8(in __m128i<byte> a, in __m128i<byte> b)
        {
            var dst = intel.m128i<byte>();
            var i = 0;
            for(var j=0; j<=15; j++)
            {
                i = j*8;
                dst[i + 7,i] = (byte)((a[i+7,i] + b[i+7,i]) >> 1);
            }

            return dst;
        }

        [MethodImpl(Inline), Op]
        public static __m256i<byte> calc(in mm256_min_epu8 src)
            => mm256_min_epu8(src.A, src.B);

        [MethodImpl(Inline)]
        public static __m256i<byte> mm256_min_epu8(in __m256i<byte> a, in __m256i<byte> b)
        {
            var dst = intel.m256i<byte>();
            for(var j=0; j<=31; j++)
            {
                var i = j*8;
                dst[i+7,i] = math.min(a[i+7,i], b[i+7,i]);
            }
            return dst;
        }
    }
}