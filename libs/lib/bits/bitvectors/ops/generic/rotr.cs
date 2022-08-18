//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Rotates source bits rightward
        /// </summary>
        /// <param name="src">The source bitvector</param>
        /// <param name="count">The rotation magnitude</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Rotr, Closures(Closure)]
        public static ScalarBits<T> rotr<T>(ScalarBits<T> src, byte count)
            where T : unmanaged
                => gbits.rotr(src.State, count);

        /// <summary>
        /// Rotates source bits rightward
        /// </summary>
        /// <param name="src">The source bitvector</param>
        /// <param name="count">The rotation magnitude</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> rotr<N,T>(ScalarBits<N,T> src, byte count)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gbits.rotr(src.State, count, (byte)src.Width);

        /// <summary>
        /// Rotates source bits rightward
        /// </summary>
        /// <param name="src">The source bitvector</param>
        /// <param name="count">The rotation magnitude</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static BitVector128<T> rotr<T>(in BitVector128<T> src, byte count)
            where T : unmanaged
                => gcpu.vrotrx(src.State, count);

        /// <summary>
        /// Rotates source bits rightward
        /// </summary>
        /// <param name="src">The source bitvector</param>
        /// <param name="count">The rotation magnitude</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static BitVector256<T> rotr<T>(in BitVector256<T> src, byte count)
            where T : unmanaged
                => gcpu.vrotrx(src.State, count);
    }
}