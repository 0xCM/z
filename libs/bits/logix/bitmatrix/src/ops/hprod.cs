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
        /// Computes the Hadamard product of the source matrix and another of the same dimension
        /// </summary>
        /// <remarks>See https://en.wikipedia.org/wiki/Hadamard_product_(matrices)</remarks>
        [MethodImpl(Inline), HProd, Closures(Closure)]
        public static ref readonly BitMatrix<T> hprod<T>(in BitMatrix<T> a, in BitMatrix<T> b, ref BitMatrix<T> dst)
            where T : unmanaged
        {
            for(var i=0; i<a.Order; i++)
            for(var j=0; j<b.Order; j++)
                dst[i,j] = a[i,j] & b[i,j];
            return ref dst;
        }

        /// <summary>
        /// Computes the Hadamard product of the source matrix and another of the same dimension
        /// </summary>
        /// <remarks>See https://en.wikipedia.org/wiki/Hadamard_product_(matrices)</remarks>
        [MethodImpl(Inline), HProd]
        public static ref readonly BitMatrix8 hprod(in BitMatrix8 a, in BitMatrix8 b, ref BitMatrix8 dst)
        {
            for(var i=0; i<a.Order; i++)
            for(var j=0; j<b.Order; j++)
                dst[i,j] = a[i,j] & b[i,j];
            return ref dst;
        }

        /// <summary>
        /// Computes the Hadamard product of the source matrix and another of the same dimension
        /// </summary>
        /// <remarks>See https://en.wikipedia.org/wiki/Hadamard_product_(matrices)</remarks>
        [MethodImpl(Inline), HProd]
        public static ref readonly BitMatrix16 hprod(in BitMatrix16 a, in BitMatrix16 b, ref BitMatrix16 dst)
        {
            for(var i=0; i<a.Order; i++)
            for(var j=0; j<b.Order; j++)
                dst[i,j] = a[i,j] & b[i,j];
            return ref dst;
        }

        /// <summary>
        /// Computes the Hadamard product of the source matrix and another of the same dimension
        /// </summary>
        /// <remarks>See https://en.wikipedia.org/wiki/Hadamard_product_(matrices)</remarks>
        [MethodImpl(Inline), HProd]
        public static ref readonly BitMatrix32 hprod(in BitMatrix32 a, in BitMatrix32 b, ref BitMatrix32 dst)
        {
            var C = BitMatrix.alloc(n32);
            for(var i=0; i<a.Order; i++)
            for(var j=0; j<b.Order; j++)
                dst[i,j] = a[i,j] & b[i,j];
            return ref dst;
        }

        /// <summary>
        /// Computes the Hadamard product of the source matrix and another of the same dimension
        /// </summary>
        /// <remarks>See https://en.wikipedia.org/wiki/Hadamard_product_(matrices)</remarks>
        [MethodImpl(Inline), HProd]
        public static ref readonly BitMatrix64 hprod(in BitMatrix64 A, in BitMatrix64 B, ref BitMatrix64 dst)
        {
            for(var i=0; i<A.Order; i++)
            for(var j=0; j<B.Order; j++)
                dst[i,j] = A[i,j] & B[i,j];
            return ref dst;
        }
    }
}