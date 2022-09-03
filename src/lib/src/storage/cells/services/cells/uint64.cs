//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Cells
    {
        /// <summary>
        /// Converts a specified cell to a <see cref='ulong'/> value
        /// </summary>
        /// <param name="src">The source cell</param>
        [MethodImpl(Inline), Op]
        public static ulong uint64(Cell64 src)
            => (ulong)src;
    }
}