//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct grids
    {

        /// <summary>
        /// Calculates memory block statistics for specified function and type parameters
        /// </summary>
        /// <param name="bc">The block count</param>
        /// <param name="bw">The block width representative</param>
        /// <param name="t">The block cell type representative</param>
        /// <typeparam name="N">The type that dermines block width</typeparam>
        /// <typeparam name="T">The type that determines cell width</typeparam>
        [MethodImpl(Inline)]
        public static BlockedGridStats<W,T> stats<W,T>(int bc, W bw = default, T t = default)
            where W : unmanaged, ITypeWidth
            where T : unmanaged
                => new BlockedGridStats<W,T>(bc);


        [MethodImpl(Inline), Op]
        public static uint gridcover(in GridMetrics src, W128 w)
        {
            var r = src.StoreSize % 16;
            return r != 0 ? r + 1 : r;
        }

        [MethodImpl(Inline), Op]
        public static uint gridcover(in GridMetrics src, W256 w)
        {
            var r = src.StoreSize % 32;
            return r != 0 ? r + 1 : r;
        }
    }
}