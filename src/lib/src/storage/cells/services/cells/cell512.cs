//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Cells
    {
        /// <summary>
        /// Presents a 512-bit vector as a 512-bit cell
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline)]
        public static Cell512 cell512<T>(in Vector512<T> src)
            where T : unmanaged
                => @as<Vector512<T>,Cell512>(src);
    }
}