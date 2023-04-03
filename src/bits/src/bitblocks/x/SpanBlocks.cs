//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [MethodImpl(Inline)]
        public static BitVector128<T> ToBitVector<T>(this BitString src, W128 n)
            where T : unmanaged
                => SpanBlocks.safeload(n,src.Pack().Recover<byte, T>()).LoadVector();

        /// <summary>
        /// Creates a 16-bit bitvector from the leading cells of a source block
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="n">The target width selector</param>
        /// <typeparam name="T">The primal cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<ushort> ToBitVector<T>(this in SpanBlock16<T> src)
            where T : unmanaged
                => src.Storage.TakeUInt16();

        /// <summary>
        /// Creates a 16-bit bitvector from the leading cells of a source block
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="n">The target width selector</param>
        /// <typeparam name="T">The primal cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<uint> ToBitVector<T>(this in SpanBlock32<T> src)
            where T : unmanaged
                => src.Storage.TakeUInt32();

        /// <summary>
        /// Creates a 64-bit bitvector from the leading cells of a source block
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="n">The target width selector</param>
        /// <typeparam name="T">The primal cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<ulong> ToBitVector<T>(this in SpanBlock64<T> src, N64 n)
            where T : unmanaged
                => src.Storage.TakeUInt64();

        /// <summary>
        /// Creates an 8-bit bitvector from the leading cells of a source block
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="n">The target width selector</param>
        /// <typeparam name="T">The primal cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<byte> ToBitVector<T>(this SpanBlock256<T> src, N8 n)
            where T : unmanaged
                => src.Storage.TakeUInt8();

        /// <summary>
        /// Creates a 16-bit bitvector from the leading cells of a source block
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="n">The target width selector</param>
        /// <typeparam name="T">The primal cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<ushort> ToBitVector<T>(this SpanBlock256<T> src, N16 n)
            where T : unmanaged
                => src.Storage.TakeUInt16();

        /// <summary>
        /// Creates a 32-bit bitvector from the leading cells of a source block
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="n">The target width selector</param>
        /// <typeparam name="T">The primal cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<uint> ToBitVector<T>(this SpanBlock256<T> src, N32 n)
            where T : unmanaged
                => src.Storage.TakeUInt32();

        /// <summary>
        /// Creates a 64-bit bitvector from the leading cells of a source block
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="n">The target width selector</param>
        /// <typeparam name="T">The primal cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<ulong> ToBitVector<T>(this SpanBlock256<T> src, N64 n)
            where T : unmanaged
                => src.Storage.TakeUInt64();        
    }
}