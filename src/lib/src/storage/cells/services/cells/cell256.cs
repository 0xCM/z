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
        /// Presents a 256-bit vector as a 256-bit cell
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline)]
        public static Cell256 cell256<T>(Vector256<T> src)
            where T : unmanaged
                => @as<Vector256<T>,Cell256>(src);
    }
}