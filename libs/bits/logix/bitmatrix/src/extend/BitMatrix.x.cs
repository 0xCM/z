//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class XTend
    {
        /// <summary>
        /// Loads a generic bitmatrix from size-conformant sequence of row bits
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <typeparam name="T">The primal data type</typeparam>
        [MethodImpl(Inline)]
        public static BitMatrix<T> ToBitMatrix<T>(this RowBits<T> src)
            where T : unmanaged
                => BitMatrix.from(src);

        [MethodImpl(Inline)]
        public static BitMatrix<N,T> AsSquare<N,T>(this BitMatrix<N,N,T> src)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                    => BitMatrix.load<N,T>(src.Content);

        [MethodImpl(Inline)]
        public static RowBits<T> ToRowBits<T>(this BitMatrix<T> src)
            where T : unmanaged
                => RowBits.load(src.Content);

        /// <summary>
        /// Exracts a contiguous bitstring that captures the defined matrix
        /// </summary>
        public static BitString ToBitString<M,N,T>(this BitMatrix<M,N,T> src)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var buffer = new byte[src.RowCount*src.ColCount];
            Span<byte> bits = buffer;
            for(var i=0;i<src.RowCount; i++)
                src[i].ToBitString().BitSeq.CopyTo(bits.Slice(i*src.ColCount));
            return BitStrings.load(buffer);
        }

        [MethodImpl(Inline)]
        public static Span<byte> Pack<M,N,T>(this BitMatrix<M,N,T> src)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => src.ToBitString().ToPackedBytes();
    }
}