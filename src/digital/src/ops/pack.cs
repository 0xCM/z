//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    partial struct Digital
    {
        [MethodImpl(Inline), Op]
        public static byte pack(HexDigitValue d0, HexDigitValue d1)
            => (byte)((uint)d0 | ((uint)d1) << 4);

        [MethodImpl(Inline), Op]
        public static uint pack(ReadOnlySpan<HexDigitValue> src, Span<byte> dst)
        {
            var count = src.Length;
            var j=0u;
            if(dst.Length >= count/2 && count % 2 == 0)
            {
                for(var i=0; i<count; i+=2)
                    seek(dst,j++) = pack(skip(src,i+1), skip(src,i));
            }
            return j;
        }
         
        /// <summary>
        /// Encodes two decimal digits d := 0x[c1][c0] for characters c2, c1 in the inclusive range [0,9]
        /// </summary>
        /// <param name="c1">The source for digit 1, the most significant digit</param>
        /// <param name="c0">The source for digit 0, the least significant digit</param>
        [MethodImpl(Inline), Op]
        public static ulong pack(Base10 @base, char c1, char c0)
        {
            const int width = 4;
            var packed = 0ul;
            packed |= (u64(@base, c0) << 0*width);
            packed |= (u64(@base, c1) << 1*width);
            return packed;
        }

        /// <summary>
        /// Encodes three decimal digits d := 0x[c2][c1][c0] for characters c2, c1, c0 in the inclusive range [0,9]
        /// </summary>
        /// <param name="c2">The source for digit 2, the most significant digit</param>
        /// <param name="c1">The source for digit 1</param>
        /// <param name="c0">The source for digit 0, the least significant digit</param>
        [MethodImpl(Inline), Op]
        public static ulong pack(Base10 @base, char c2, char c1, char c0)
        {
            const int width = 4;
            var packed = 0ul;
            packed |= (u64(@base, c0) << 0*width);
            packed |= (u64(@base, c1) << 1*width);
            packed |= (u64(@base, c2) << 2*width);
            return packed;
        }

        /// <summary>
        /// Encodes four decimal digits d := 0x[c3][c2][c1][c0] for characters c3, c2, c1, c0 in the inclusive range [0,9]
        /// </summary>
        /// <param name="c3">The source for digit 3, the most significant digit</param>
        /// <param name="c2">The source for digit 2</param>
        /// <param name="c1">The source for digit 1</param>
        /// <param name="c0">The source for digit 0, the least significant digit</param>
        [MethodImpl(Inline), Op]
        public static ulong pack(Base10 @base, char c3, char c2, char c1, char c0)
        {
            const int width = 4;
            var packed = 0ul;
            packed |= (u64(@base, c0) << 0*width);
            packed |= (u64(@base, c1) << 1*width);
            packed |= (u64(@base, c2) << 2*width);
            packed |= (u64(@base, c3) << 3*width);
            return packed;
        }

        /// <summary>
        /// Encodes five decimal digits d := 0x[c4][c3][c2][c1][c0] for characters c4, c3, c2, c1, c0 in the inclusive range [0,9]
        /// </summary>
        /// <param name="c4">The source for digit 4, the most significant digit</param>
        /// <param name="c3">The source for digit 3</param>
        /// <param name="c2">The source for digit 2</param>
        /// <param name="c1">The source for digit 1</param>
        /// <param name="c0">The source for digit 0, the least significant digit</param>
        [MethodImpl(Inline), Op]
        public static ulong pack(Base10 @base, char c4, char c3, char c2, char c1, char c0)
        {
            const int width = 4;
            var packed = 0ul;
            packed |= (u64(@base, c0) << 0*width);
            packed |= (u64(@base, c1) << 1*width);
            packed |= (u64(@base, c2) << 2*width);
            packed |= (u64(@base, c3) << 3*width);
            packed |= (u64(@base, c4) << 4*width);
            return packed;
        }

        /// <summary>
        /// Encodes eight decimal digits d := 0x[c7][c6][c5][c4][c3][c2][c1][c0] for characters c7, c6, c5, c4, c3, c2, c1, c0 in the inclusive range [0,9]
        /// </summary>
        /// <param name="c7">The source for digit 7, the most significant digit</param>
        /// <param name="c6">The source for digit 6</param>
        /// <param name="c5">The source for digit 5</param>
        /// <param name="c4">The source for digit 4</param>
        /// <param name="c3">The source for digit 3</param>
        /// <param name="c2">The source for digit 2</param>
        /// <param name="c1">The source for digit 1</param>
        /// <param name="c0">The source for digit 0, the least significant digit</param>
        [MethodImpl(Inline), Op]
        public static ulong pack(Base10 @base, char c7, char c6, char c5, char c4, char c3, char c2, char c1, char c0)
        {
            const int width = 4;
            var packed = 0ul;
            packed |= (u64(@base, c0) << 0*width);
            packed |= (u64(@base, c1) << 1*width);
            packed |= (u64(@base, c2) << 2*width);
            packed |= (u64(@base, c3) << 3*width);
            packed |= (u64(@base, c4) << 4*width);
            packed |= (u64(@base, c5) << 5*width);
            packed |= (u64(@base, c6) << 6*width);
            packed |= (u64(@base, c7) << 7*width);
            return packed;
        }
    }
}