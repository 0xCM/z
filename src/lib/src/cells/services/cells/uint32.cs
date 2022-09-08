//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial class Cells
    {
        /// <summary>
        /// Converts a specified cell to a <see cref='uint'/> value
        /// </summary>
        /// <param name="src">The source cell</param>
        [MethodImpl(Inline), Op]
        public static uint uint32(Cell32 src)
            => (uint)src;
    }
}