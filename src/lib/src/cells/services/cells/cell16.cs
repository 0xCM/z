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
        /// Creates a <see cref='Cell16'/> from a specified <typeparamref name='T'/> value
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static Cell16 cell16<T>(T src)
            where T : unmanaged
                => new Cell16(@as<T,ushort>(src));
    }
}