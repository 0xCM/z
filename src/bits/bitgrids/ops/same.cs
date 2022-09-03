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
        /// Returns 1 if the source grids have identical content and 0 otherwise
        /// </summary>
        /// <param name="a">The left grid</param>
        /// <param name="b">The right grid</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline)]
        public static bit same<T>(BitGrid32<T> a, BitGrid32<T> b)
            where T : unmanaged
                => math.eq(a,b);

        /// <summary>
        /// Returns 1 if the source grids have identical content and 0 otherwise
        /// </summary>
        /// <param name="a">The left grid</param>
        /// <param name="b">The right grid</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline)]
        public static bit same<T>(BitGrid64<T> a, BitGrid64<T> b)
            where T : unmanaged
                => math.eq(a,b);

        /// <summary>
        /// Returns 1 if the source grids have identical content and 0 otherwise
        /// </summary>
        /// <param name="gx">The left grid</param>
        /// <param name="gy">The right grid</param>
        /// <typeparam name="M"></typeparam>
        /// <typeparam name="N"></typeparam>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline)]
        public static bit same<M,N,T>(in BitGrid128<M,N,T> gx, in BitGrid128<M,N,T> gy)
            where T : unmanaged
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
                => gcpu.vsame<T>(gx,gy);

        /// <summary>
        /// Returns 1 if the source grids have identical content and 0 otherwise
        /// </summary>
        /// <param name="gx">The left grid</param>
        /// <param name="gy">The right grid</param>
        /// <typeparam name="M"></typeparam>
        /// <typeparam name="N"></typeparam>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline)]
        public static bit same<M,N,T>(in BitGrid256<M,N,T> gx, in BitGrid256<M,N,T> gy)
            where T : unmanaged
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
                => gcpu.vsame<T>(gx,gy);

        [MethodImpl(Inline)]
        public static bit same<T>(in BitSpanBlocks256<T> gx, in BitSpanBlocks256<T> gy)
            where T : unmanaged
        {
            var blocks = gx.BlockCount;
            for(var i=0; i<blocks; i++)
                if(!gcpu.vsame(gx[i],gy[i]))
                       return false;
            return true;
        }

        /// <summary>
        /// Returns 1 if the source grids have identical content and 0 otherwise
        /// </summary>
        /// <param name="gx">The left grid</param>
        /// <param name="gy">The right grid</param>
        /// <typeparam name="M"></typeparam>
        /// <typeparam name="N"></typeparam>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline)]
        public static bit same<M,N,T>(in BitGrid<M,N,T> gx, in BitGrid<M,N,T> gy)
            where T : unmanaged
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
        {
            var blocks = gx.BlockCount;
            for(var i=0; i<blocks; i++)
                if(!gcpu.vsame(gx[i],gy[i]))
                       return false;
            return true;
        }
    }
}