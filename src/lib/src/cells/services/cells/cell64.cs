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
        /// Creates a <see cref='Cell64'/> from a specified <typeparamref name='T'/> value
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Cell64 cell64<T>(T src)
            where T : unmanaged
                => @as<T,Cell64>(src);
    }
}