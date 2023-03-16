//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Converts the vector to a bitstring representation
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="N">The bitvector width</typeparam>
        /// <typeparam name="T">The storage cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitString bitstring<T>(BitVector128<T> x)
            where T : unmanaged
                => vbits.bitstring(x.State, x.Width);

        /// <summary>
        /// Converts the vector to a bitstring representation
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="N">The bitvector width</typeparam>
        /// <typeparam name="T">The storage cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitString bitstring<T>(BitVector256<T> x)
            where T : unmanaged
                => vbits.bitstring(x.State, x.Width);


        [MethodImpl(Inline), Op]
        public static BitString bitstring<T>(BitVector<T> src)
            where T : unmanaged, IEquatable<T>
                => new BitString(sys.bytes(src.State));
   }
}