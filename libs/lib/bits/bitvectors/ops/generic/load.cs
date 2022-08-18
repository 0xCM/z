//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        [MethodImpl(Inline), Op]
        public static BitVector128<ulong> load(W128 w, ulong a, ulong b)
            => cpu.vparts(w,a,b);

        [MethodImpl(Inline), Op]
        public static BitVector128<uint> load(W128 w, uint a0, uint a1, uint a2, uint a3)
            => cpu.vparts(w,a0,a1,a2,a3);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitVector128<T> load<T>(W128 w, ReadOnlySpan<T> src)
            where T : unmanaged
                => gcpu.vload(w,src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitVector256<T> load<T>(W256 w, ReadOnlySpan<T> src)
            where T : unmanaged
                => gcpu.vload(w,src);

        /// <summary>
        /// Creates a generic bitvector
        /// </summary>
        /// <param name="src">The source cell</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ScalarBits<T> load<T>(T src)
            where T : unmanaged
                => new ScalarBits<T>(src);

        /// <summary>
        /// Creates a generic bitvector from a span of bytes
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="n">The bitvector length</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ScalarBits<T> load<T>(Span<byte> src)
            where T : unmanaged
                => load(src.Take<T>());

        /// <summary>
        /// Loads an bitvector of minimal size from a source bitstring
        /// </summary>
        /// <param name="src">The bitstring source</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ScalarBits<T> load<T>(BitString src)
            where T : unmanaged
                => load<T>(src.ToPackedBytes());

        /// <summary>
        /// Creates a byte-generic bitvector
        /// </summary>
        [MethodImpl(Inline), Op]
        public static ScalarBits<byte> load(N8 n8, byte a)
            => a;

        /// <summary>
        /// Creates a byte-generic bitvector from 4 explicit bytes
        /// </summary>
        /// <param name="src">The source bitstring</param>
        [MethodImpl(Inline), Op]
        public static ScalarBits<uint> load(byte x0, byte x1, byte x2, byte x3)
            => load(bits.join(x0,x1,x2,x3));
    }
}