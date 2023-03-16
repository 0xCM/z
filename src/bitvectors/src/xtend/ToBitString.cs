//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XBv
    {
        // [MethodImpl(Inline), Op]
        // public static BitVector128<ulong> load(W128 w, ulong a, ulong b)
        //     => vcpu.vparts(w,a,b);

        // [MethodImpl(Inline), Op]
        // public static BitVector128<uint> load(W128 w, uint a0, uint a1, uint a2, uint a3)
        //     => vcpu.vparts(w,a0,a1,a2,a3);

        // [MethodImpl(Inline)]
        // public static BitVector128<T> load<T>(W128 w, ReadOnlySpan<T> src)
        //     where T : unmanaged
        //         => vgcpu.vload(w,src);

        // [MethodImpl(Inline)]
        // public static BitVector256<T> load<T>(W256 w, ReadOnlySpan<T> src)
        //     where T : unmanaged
        //         => vgcpu.vload(w,src);        

        /// <summary>
        /// Converts the vector to a bitstring
        /// </summary>
        [MethodImpl(Inline)]
        public static BitString ToBitString<T>(this BitVector128<T> src)
            where T : unmanaged
                => vbits.bitstring(src.State, src.Width);

        /// <summary>
        /// Creates the vector's bitstring representation
        /// </summary>
        /// <param name="src">The source bitvector</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString(this BitVector4 src)
            => BitVectors.bitstring(src);

        /// <summary>
        /// Creates the vector's bitstring representation
        /// </summary>
        /// <param name="src">The source bitvector</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString(this BitVector8 src)
            => BitVectors.bitstring(src);

        /// <summary>
        /// Creates the vector's bitstring representation
        /// </summary>
        /// <param name="src">The source bitvector</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString(this BitVector16 src)
            => BitVectors.bitstring(src);

        /// <summary>
        /// Creates the vector's bitstring representation
        /// </summary>
        /// <param name="src">The source bitvector</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString(this BitVector24 src)
             => BitVectors.bitstring(src);

        /// <summary>
        /// Creates the vector's bitstring representation
        /// </summary>
        /// <param name="src">The source bitvector</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString(this BitVector32 src)
             => BitVectors.bitstring(src);

        /// <summary>
        /// Creates the vector's bitstring representation
        /// </summary>
        /// <param name="src">The source bitvector</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString(this BitVector64 x)
            => BitVectors.bitstring(x);
    }
}