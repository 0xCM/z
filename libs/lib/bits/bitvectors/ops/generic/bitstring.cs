//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Converts the vector content to a bitring representation
        /// </summary>
        [MethodImpl(Inline)]
        public static BitString bitstring<N,T>(ScalarBits<N,T> x)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => BitStrings.scalar<T>(x.State, x.Width);

        /// <summary>
        /// Converts the vector content to a bitring representation
        /// </summary>
        [MethodImpl(Inline)]
        public static BitString bitstring<N,T>(ScalarBits<N,T> x, byte[] storage)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => BitStrings.scalar<T>(x.State, storage, x.Width);

        /// <summary>
        /// Converts the vector to a bitstring representation
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="N">The bitvector width</typeparam>
        /// <typeparam name="T">The storage cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitString bitstring<T>(BitVector128<T> x)
            where T : unmanaged
                => BitStrings.load(x.State, x.Width);

        /// <summary>
        /// Converts the vector to a bitstring representation
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="N">The bitvector width</typeparam>
        /// <typeparam name="T">The storage cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitString bitstring<T>(BitVector256<T> x)
            where T : unmanaged
                => BitStrings.load(x.State, x.Width);

        /// <summary>
        /// Extracts the represented data as a bitstring
        /// </summary>
        [MethodImpl(Inline), Op]
        public static BitString bitstring<T>(ScalarBits<T> src)
            where T : unmanaged
                => BitStrings.scalar<T>(src.State);

        /// <summary>
        /// Extracts the represented data as a bitstring truncated to a specified width
        /// </summary>
        [MethodImpl(Inline), Op]
        public static BitString bitstring<T>(ScalarBits<T> src, int width)
            where T : unmanaged
                => BitStrings.scalar<T>(src.State, width);

        [MethodImpl(Inline), Op]
        public static BitString bitstring<T>(BitVector<T> src)
            where T : unmanaged, IEquatable<T>
                => new BitString(core.bytes(src.State));
   }
}