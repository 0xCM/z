//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class BitMatrix
    {
        /// <summary>
        /// Projects the bits of a fixed primal bitmatrix into a generic target matrix of the same order
        /// </summary>
        /// <param name="src">The source matrix</param>
        /// <param name="dst">The target matrix</param>
        /// <typeparam name="T">The element type of the target matrix</typeparam>
        [MethodImpl(Inline), Unpack, Closures(Closure)]
        public static ref readonly Matrix<N16,T> unpack32<T>(in BitMatrix16 src, in Matrix<N16,T> dst)
            where T : unmanaged
        {
            gpack.unpack32(src.Content, dst.Data.AsSpan());
            return ref dst;
        }

        /// <summary>
        /// Projects the bits of a fixed primal bitmatrix into a generic target matrix of the same order
        /// </summary>
        /// <param name="src">The source matrix</param>
        /// <param name="dst">The target matrix</param>
        /// <typeparam name="T">The element type of the target matrix</typeparam>
        [MethodImpl(Inline), Unpack, Closures(Closure)]
        public static ref readonly Matrix<N8,T> unpack32<T>(in BitMatrix8 src, in Matrix<N8,T> dst)
            where T : unmanaged
        {
            gpack.unpack32(src.Bytes, dst.Data.AsSpan());
            return ref dst;
        }

        /// <summary>
        /// Projects the bits of a fixed primal bitmatrix into a generic target matrix of the same order
        /// </summary>
        /// <param name="src">The source matrix</param>
        /// <param name="dst">The target matrix</param>
        /// <typeparam name="T">The element type of the target matrix</typeparam>
        [MethodImpl(Inline), Unpack, Closures(Closure)]
        public static ref readonly Matrix<N32,T> unpack32<T>(in BitMatrix32 src, in Matrix<N32,T> dst)
            where T : unmanaged
        {
            gpack.unpack32(src.Content, dst.Data.AsSpan());
            return ref dst;
        }

        /// <summary>
        /// Projects the bits of a fixed primal bitmatrix into a generic target matrix of the same order
        /// </summary>
        /// <param name="src">The source matrix</param>
        /// <param name="dst">The target matrix</param>
        /// <typeparam name="T">The element type of the target matrix</typeparam>
        [MethodImpl(Inline), Unpack, Closures(Closure)]
        public static ref readonly Matrix<N64,T> unpack32<T>(in BitMatrix64 src, in Matrix<N64,T> dst)
            where T : unmanaged
        {
            gpack.unpack32(src.Content, dst.Data.AsSpan());
            return ref dst;
        }

        /// <summary>
        ///  Projects the bits in the source matrix onto cells of a conventional matrix
        /// </summary>
        /// <param name="src">The source matrix</param>
        /// <param name="dst">The target matrix</param>
        /// <typeparam name="T">The element type of the target matrix</typeparam>
        [MethodImpl(Inline)]
        public static ref Matrix<N,T> unpack32<N,S,T>(in BitMatrix<S> src, ref Matrix<N,T> Z)
            where N : unmanaged, ITypeNat
            where S : unmanaged
            where T : unmanaged
        {
            gpack.unpack32(src.Content, Z.Data.AsSpan());
            return ref Z;
        }

        /// <summary>
        /// Projects the bits of a generic sqare bitmatix of natural order into a generic target matrix of the same order
        /// </summary>
        /// <param name="src">The source matrix</param>
        /// <param name="dst">The target matrix</param>
        /// <typeparam name="N">The orer type</typeparam>
        /// <typeparam name="S">The source matrix element type</typeparam>
        /// <typeparam name="T">The target matrix element type</typeparam>
        [MethodImpl(Inline)]
        public static ref Matrix<N,T> unpack32<N,S,T>(in BitMatrix<N,S> src, ref Matrix<N,T> dst)
            where S : unmanaged
            where T : unmanaged
            where N : unmanaged, ITypeNat
        {
            gpack.unpack32(src.Content, dst.Data.AsSpan());
            return ref dst;
        }

        /// <summary>
        /// Projects the bits of a generic bitmatix of natural dimensions into a generic matrix of the same dimensions
        /// </summary>
        /// <param name="src">The source matrix</param>
        /// <param name="dst">The target matrix</param>
        /// <typeparam name="M">The row dimension type</typeparam>
        /// <typeparam name="N">The col dimension type</typeparam>
        /// <typeparam name="S">The source matrix element type</typeparam>
        /// <typeparam name="T">The target matrix element type</typeparam>
        [MethodImpl(Inline)]
        public static ref Matrix<M,N,T> unpack32<M,N,S,T>(in BitMatrix<M,N,S> src, ref Matrix<M,N,T> dst)
            where S : unmanaged
            where T : unmanaged
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
        {
            gpack.unpack32(src.Content, dst.Data.AsSpan());
            return ref dst;
        }

        /// <summary>
        /// Projects the bits of a square generic bitmatix of natural order into a generic block matrix of the same order
        /// </summary>
        /// <param name="src">The source matrix</param>
        /// <param name="dst">The target matrix</param>
        /// <typeparam name="M">The row dimension type</typeparam>
        /// <typeparam name="N">The col dimension type</typeparam>
        /// <typeparam name="S">The source matrix element type</typeparam>
        /// <typeparam name="T">The target matrix element type</typeparam>
        [MethodImpl(Inline)]
        public static ref Matrix256<N,T> unpack32<N,S,T>(in BitMatrix<N,S> src, ref Matrix256<N,T> dst)
            where S : unmanaged
            where T : unmanaged
            where N : unmanaged, ITypeNat
        {
            gpack.unpack32(src.Content, dst.Unblocked);
            return ref dst;
        }

        /// <summary>
        /// Projects the bits of a generic bitmatix of natural dimensions into a generic block matrix of the same dimensions
        /// </summary>
        /// <param name="src">The source matrix</param>
        /// <param name="dst">The target matrix</param>
        /// <typeparam name="M">The row dimension type</typeparam>
        /// <typeparam name="N">The col dimension type</typeparam>
        /// <typeparam name="S">The source matrix element type</typeparam>
        /// <typeparam name="T">The target matrix element type</typeparam>
        [MethodImpl(Inline)]
        public static ref Matrix256<M,N,T> unpack32<M,N,S,T>(in BitMatrix<M,N,S> src, ref Matrix256<M,N,T> dst)
            where S : unmanaged
            where T : unmanaged
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
        {
            gpack.unpack32(src.Content, dst.Unblocked);
            return ref dst;
        }

        /// <summary>
        /// Projects each bit value in the source matrix to a cell in a caller-supplied conventional matrix
        /// </summary>
        /// <param name="A">The source bitmatrix</param>
        /// <param name="Z">The target matrix</param>
        [MethodImpl(Inline), Unpack]
        public static ref readonly Matrix<N8,Bit32> unpack32(in BitMatrix8 A, in Matrix<N8,Bit32> Z)
        {
            gpack.unpack32(A.Bytes, Z.Data);
            return ref Z;
        }

        /// <summary>
        /// Projects each bit value in the source matrix to a cell in a caller-supplied conventional matrix
        /// </summary>
        /// <param name="A">The source bitmatrix</param>
        /// <param name="Z">The target matrix</param>
        [MethodImpl(Inline), Unpack]
        public static ref readonly Matrix<N8,Bit32> unpack32(in BitMatrix<byte> A, in Matrix<N8,Bit32> Z)
        {
            gpack.unpack32(A.Content, Z.Data);
            return ref Z;
        }

        /// <summary>
        /// Projects each bit value in the source matrix to a cell in a caller-supplied conventional matrix
        /// </summary>
        /// <param name="A">The source bitmatrix</param>
        /// <param name="Z">The target matrix</param>
        [MethodImpl(Inline), Unpack]
        public static ref readonly Matrix<N16,Bit32> unpack32(in BitMatrix16 A, in Matrix<N16,Bit32> Z)
        {
            gpack.unpack32(A.Content, Z.Data);
            return ref Z;
        }

        /// <summary>
        /// Projects each bit value in the source matrix to a cell in a caller-supplied conventional matrix
        /// </summary>
        /// <param name="A">The source bitmatrix</param>
        /// <param name="Z">The target matrix</param>
        [MethodImpl(Inline), Unpack]
        public static ref readonly Matrix<N16,Bit32> unpack32(in BitMatrix<ushort> A, in Matrix<N16,Bit32> Z)
        {
            gpack.unpack32(A.Content, Z.Data);
            return ref Z;
        }

        /// <summary>
        /// Projects each bit value in the source matrix to a cell in a caller-supplied conventional matrix
        /// </summary>
        /// <param name="A">The source bitmatrix</param>
        /// <param name="Z">The target matrix</param>
        [MethodImpl(Inline), Unpack]
        public static ref readonly Matrix<N32,Bit32> unpack32(in BitMatrix32 A, in Matrix<N32,Bit32> Z)
        {
            gpack.unpack32(A.Content, Z.Data);
            return ref Z;
        }

        /// <summary>
        /// Projects each bit value in the source matrix to a cell in a caller-supplied conventional matrix
        /// </summary>
        /// <param name="A">The source bitmatrix</param>
        /// <param name="Z">The target matrix</param>
        [MethodImpl(Inline), Unpack]
        public static ref readonly Matrix<N32,Bit32> unpack32(in BitMatrix<uint> A, in Matrix<N32,Bit32> Z)
        {
            gpack.unpack32(A.Content, Z.Data);
            return ref Z;
        }

        /// <summary>
        /// Projects each bit value in the source matrix to a cell in a caller-supplied conventional matrix
        /// </summary>
        /// <param name="A">The source bitmatrix</param>
        /// <param name="Z">The target matrix</param>
        [MethodImpl(Inline), Unpack]
        public static ref readonly Matrix<N64,Bit32> unpack32(in BitMatrix64 A, in Matrix<N64,Bit32> Z)
        {
            gpack.unpack32(A.Content, Z.Data);
            return ref Z;
        }

        /// <summary>
        /// Projects each bit value in the source matrix to a cell in a caller-supplied conventional matrix
        /// </summary>
        /// <param name="A">The source bitmatrix</param>
        /// <param name="Z">The target matrix</param>
        [MethodImpl(Inline), Unpack]
        public static ref readonly Matrix<N64,Bit32> unpack32(in BitMatrix<ulong> A, in Matrix<N64,Bit32> Z)
        {
            gpack.unpack32(A.Content, Z.Data);
            return ref Z;
        }
   }
}