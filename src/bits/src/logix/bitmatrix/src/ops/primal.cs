//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    partial class BitMatrix
    {
        /// <summary>
        /// Defines a primal bitmatrix of order 4
        /// </summary>
        /// <param name="n">The order selector</param>
        /// <param name="src">The data used to populate the matrix</param>
        [MethodImpl(Inline), Op]
        public static BitMatrix4 primal(N4 n, ushort src)
            => BitMatrix4.From(src);

        /// <summary>
        /// Defines a primal bitmatrix of order 4
        /// </summary>
        /// <param name="n">The order selector</param>
        /// <param name="src">The data used to populate the matrix</param>
        [MethodImpl(Inline), Op]
        public static BitMatrix4 primal(N4 n, BitVector4[] rows)
        {
            ushort result = 0;
            for(var i=0; i<rows.Length; i++)
                result |= (ushort)(rows[i].State << 4*i);
            return result;
        }

        /// <summary>
        /// Defines a primal bitmatrix of order 8
        /// </summary>
        /// <param name="n">The order selector</param>
        /// <param name="src">The data used to populate the matrix</param>
        [MethodImpl(Inline), Op]
        public static BitMatrix8 primal(N8 n, Span<byte> src)
            => new BitMatrix8(src);

        /// <summary>
        /// Defines a primal bitmatrix of order 8
        /// </summary>
        /// <param name="n">The order selector</param>
        /// <param name="src">The data used to populate the matrix</param>
        public static BitMatrix8 primal(N8 n, ReadOnlySpan<byte> src)
            => new BitMatrix8(src.Replicate());

        /// <summary>
        /// Defines a matrix from two 32-bit unsigned integers; the upper value contains
        /// the data for rows 0...3 and the lower value contains the dat for rows [4 ... 7]
        /// </summary>
        /// <param name="lo">The upper row data</param>
        /// <param name="hi">The lower row data</param>
        [MethodImpl(Inline), Op]
        public static BitMatrix8 primal(N8 n, uint lo, uint hi)
            => new BitMatrix8(Z0.bits.join(lo, hi));

        [MethodImpl(Inline), Op]
        public static BitMatrix8 primal(N8 n, ulong src)
            => new BitMatrix8(src);

        /// <summary>
        /// Defines a primal bitmatrix of order 16
        /// </summary>
        /// <param name="n">The order selector</param>
        /// <param name="src">The data used to populate the matrix</param>
        [MethodImpl(Inline), Op]
        public static BitMatrix16 primal(N16 n, Span<ushort> src)
            => new BitMatrix16(src);

        /// <summary>
        /// Defines a primal bitmatrix of order 16
        /// </summary>
        /// <param name="n">The order selector</param>
        /// <param name="src">The data used to populate the matrix</param>
        [MethodImpl(Inline), Op]
        public static BitMatrix16 primal(N16 n, ReadOnlySpan<byte> src)
            => new BitMatrix16(src.AsUInt16().Replicate());

        /// <summary>
        /// Defines a primal bitmatrix of order 32
        /// </summary>
        /// <param name="n">The order selector</param>
        /// <param name="src">The data used to populate the matrix</param>
        [MethodImpl(Inline), Op]
        public static BitMatrix32 primal(N32 n, uint[] src)
            => new BitMatrix32(src);

        /// <summary>
        /// Defines a primal bitmatrix of order 64
        /// </summary>
        /// <param name="n">The order selector</param>
        /// <param name="src">The data used to populate the matrix</param>
        [MethodImpl(Inline), Op]
        public static BitMatrix64 primal(N64 n, Span<ulong> src)
            => new BitMatrix64(src);

        /// <summary>
        /// Defines a primal bitmatrix of order 64
        /// </summary>
        /// <param name="n">The order selector</param>
        /// <param name="src">The data used to populate the matrix</param>
        [MethodImpl(Inline), Op]
        public static BitMatrix64 primal(N64 n, ReadOnlySpan<byte> src)
            => new BitMatrix64(src.AsUInt64().Replicate());

        [MethodImpl(Inline), Op]
        public static BitMatrix8 primal(N8 n8, byte row0 = 0, byte row1 = 0, byte row2 = 0, byte row3 = 0,
            byte row4 = 0, byte row5 = 0, byte row6 = 0, byte row7 = 0)
               => new BitMatrix8(array(row0,row1,row2,row3,row4,row5,row6, row7));
    }
}