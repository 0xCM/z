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
        /// Computes the grid cell count
        /// </summary>
        /// <param name="src">The grid dimension</param>
        [MethodImpl(Inline), Op]
        public static ulong points(GridDim src)
            => (ulong)src.M*(ulong)src.N;
    }
}