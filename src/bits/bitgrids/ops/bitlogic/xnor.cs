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
        /// Computes the bitwise XNOR between generic bitgrids
        /// </summary>
        /// <param name="gx">The left grid</param>
        /// <param name="gy">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Xnor, Closures(UInt8x16k)]
        public static BitGrid16<T> xnor<T>(BitGrid16<T> gx, BitGrid16<T> gy)
            where T : unmanaged
                => init16<T>(math.xnor(gx,gy));

        /// <summary>
        /// Computes the bitwise XNOR between generic bitgrids
        /// </summary>
        /// <param name="gx">The left grid</param>
        /// <param name="gy">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Xnor, Closures(UInt8x16x32k)]
        public static BitGrid32<T> xnor<T>(BitGrid32<T> gx, BitGrid32<T> gy)
            where T : unmanaged
                => init32<T>(math.xnor(gx,gy));

        /// <summary>
        /// Computes the bitwise XNOR between generic bitgrids
        /// </summary>
        /// <param name="gx">The left grid</param>
        /// <param name="gy">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Xnor, Closures(UnsignedInts)]
        public static BitGrid64<T> xnor<T>(BitGrid64<T> gx, BitGrid64<T> gy)
            where T : unmanaged
                => init64<T>(math.xnor(gx,gy));

        /// <summary>
        /// Computes the bitwise XNOR between generic bitgrids and stores the result to a caller-supplied target
        /// </summary>
        /// <param name="gx">The left grid</param>
        /// <param name="gy">The right grid</param>
        /// <param name="gz">The target grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Xnor, Closures(UnsignedInts)]
        public static ref readonly BitSpanBlocks256<T> xnor<T>(in BitSpanBlocks256<T> gx, in BitSpanBlocks256<T> gy, in BitSpanBlocks256<T> gz)
            where T : unmanaged
        {
            var blocks = gz.BlockCount;
            for(var i=0; i<blocks; i++)
                gz[i] = gcpu.vxnor(gx[i],gy[i]);
            return ref gz;
        }

        /// <summary>
        /// Computes the bitwise XNOR between natural bitgrids
        /// </summary>
        /// <param name="gx">The left grid</param>
        /// <param name="gy">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid32<M,N,T> xnor<M,N,T>(BitGrid32<M,N,T> gx, BitGrid32<M,N,T> gy)
            where T : unmanaged
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
                => math.xnor(gx,gy);

        /// <summary>
        /// Computes the bitwise XNOR between natural bitgrids
        /// </summary>
        /// <param name="gx">The left grid</param>
        /// <param name="gy">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid64<M,N,T> xnor<M,N,T>(BitGrid64<M,N,T> gx, BitGrid64<M,N,T> gy)
            where T : unmanaged
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
                => math.xnor(gx,gy);

        /// <summary>
        /// Computes the bitwise XNOR between natural bitgrids
        /// </summary>
        /// <param name="gx">The left grid</param>
        /// <param name="gy">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid128<M,N,T> xnor<M,N,T>(in BitGrid128<M,N,T> gx, in BitGrid128<M,N,T> gy)
            where T : unmanaged
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
                => gcpu.vxnor<T>(gx,gy);

        /// <summary>
        /// Computes the bitwise XNOR between 256-bit fixed-width natural bitgrids
        /// </summary>
        /// <param name="gx">The left grid</param>
        /// <param name="gy">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid256<M,N,T> xnor<M,N,T>(in BitGrid256<M,N,T> gx, in BitGrid256<M,N,T> gy)
            where T : unmanaged
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
                => gcpu.vxnor<T>(gx,gy);

        /// <summary>
        /// Computes the bitwise XNOR between natural bitgrids and stores the result to a caller-supplied target
        /// </summary>
        /// <param name="gx">The left grid</param>
        /// <param name="gy">The right grid</param>
        /// <param name="gz">The target grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static ref readonly BitGrid<M,N,T> xnor<M,N,T>(in BitGrid<M,N,T> gx, in BitGrid<M,N,T> gy, in BitGrid<M,N,T> gz)
            where T : unmanaged
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
        {
            var blocks = gz.BlockCount;
            for(var i=0; i<blocks; i++)
                gz[i] = gcpu.vxnor(gx[i],gy[i]);
            return ref gz;
        }

        /// <summary>
        /// Computes the bitwise XNOR between generic bitgrids and returns the allocated result
        /// </summary>
        /// <param name="gx">The left grid</param>
        /// <param name="gy">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid<M,N,T> xnor<M,N,T>(in BitGrid<M,N,T> gx, in BitGrid<M,N,T> gy)
            where T : unmanaged
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
        {
            var gz = alloc<M,N,T>();
            xnor(gx,gy,gz);
            return gz;
        }
    }
}