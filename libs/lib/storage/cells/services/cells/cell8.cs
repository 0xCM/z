//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Cells
    {
        /// <summary>
        /// Creates a <see cref='Cell8'/> from a specified <typeparamref name='T'/> value
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static Cell8 cell8<T>(T src)
            where T : unmanaged
                => new Cell8(@as<T,byte>(src));
    }
}