//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class BitGrid
    {
        /// <summary>
        /// Computes the bitwise AND between fixed-width 16-bit generic bitgrids
        /// </summary>
        /// <param name="gx">The left grid</param>
        /// <param name="gy">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), And, Closures(UInt8x16k)]
        public static BitGrid16<T> and<T>(BitGrid16<T> gx, BitGrid16<T> gy)
            where T : unmanaged
                => init16<T>(math.and(gx,gy));

        /// <summary>
        /// Computes the bitwise AND between fixed-width 32-bit generic bitgrids
        /// </summary>
        /// <param name="gx">The left grid</param>
        /// <param name="gy">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), And, Closures(UInt8x16x32k)]
        public static BitGrid32<T> and<T>(BitGrid32<T> gx, BitGrid32<T> gy)
            where T : unmanaged
                => init32<T>(math.and(gx,gy));

        /// <summary>
        /// Computes the bitwise AND between fixed-width 64-bit grids
        /// </summary>
        /// <param name="gx">The left grid</param>
        /// <param name="gy">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), And, Closures(UnsignedInts)]
        public static BitGrid64<T> and<T>(BitGrid64<T> gx, BitGrid64<T> gy)
            where T : unmanaged
                => init64<T>(math.and(gx,gy));

        /// <summary>
        /// Computes the bitwise AND between generic bitgrids and stores the result to a caller-supplied target
        /// </summary>
        /// <param name="a">The left grid</param>
        /// <param name="b">The right grid</param>
        /// <param name="dst">The target grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), And, Closures(UnsignedInts)]
        public static ref readonly BitSpanBlocks256<T> and<T>(in BitSpanBlocks256<T> a, in BitSpanBlocks256<T> b, in BitSpanBlocks256<T> dst)
            where T : unmanaged
        {
            var blocks = dst.BlockCount;
            for(var i=0; i<blocks; i++)
                dst[i] = gcpu.vand(a[i],b[i]);
            return ref dst;
        }

        /// <summary>
        /// Computes the bitwise AND between fixed-width natural bitgrids
        /// </summary>
        /// <param name="a">The left grid</param>
        /// <param name="b">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid16<M,N,T> and<M,N,T>(BitGrid16<M,N,T> a, BitGrid16<M,N,T> b)
            where T : unmanaged
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
                => math.and(a,b);

        /// <summary>
        /// Computes the bitwise AND between fixed-width natural bitgrids
        /// </summary>
        /// <param name="a">The left grid</param>
        /// <param name="b">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid32<M,N,T> and<M,N,T>(BitGrid32<M,N,T> a, BitGrid32<M,N,T> b)
            where T : unmanaged
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
                => math.and(a,b);

        /// <summary>
        /// Computes the bitwise AND between fixed-width natural bitgrids
        /// </summary>
        /// <param name="a">The left grid</param>
        /// <param name="b">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid64<M,N,T> and<M,N,T>(BitGrid64<M,N,T> a, BitGrid64<M,N,T> b)
            where T : unmanaged
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
                => math.and(a,b);

        /// <summary>
        /// Computes the bitwise AND between fixed-width natural bitgrids
        /// </summary>
        /// <param name="a">The left grid</param>
        /// <param name="b">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid128<M,N,T> and<M,N,T>(in BitGrid128<M,N,T> a, in BitGrid128<M,N,T> b)
            where T : unmanaged
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
                => gcpu.vand<T>(a,b);

        /// <summary>
        /// Computes the bitwise AND between fixed-width natural bitgrids
        /// </summary>
        /// <param name="a">The left grid</param>
        /// <param name="b">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid256<M,N,T> and<M,N,T>(in BitGrid256<M,N,T> a, in BitGrid256<M,N,T> b)
            where T : unmanaged
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
                => gcpu.vand<T>(a,b);

        /// <summary>
        /// Computes the bitwise AND between natural bitgrids and stores the result to a caller-supplied target
        /// </summary>
        /// <param name="a">The left grid</param>
        /// <param name="b">The right grid</param>
        /// <param name="dst">The target grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static ref readonly BitGrid<M,N,T> and<M,N,T>(in BitGrid<M,N,T> a, in BitGrid<M,N,T> b, in BitGrid<M,N,T> dst)
            where T : unmanaged
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
        {
            var blocks = dst.BlockCount;
            for(var i=0; i<blocks; i++)
                dst[i] = gcpu.vand(a[i],b[i]);
            return ref dst;
        }
    }
}