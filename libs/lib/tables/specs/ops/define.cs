//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct DataLayouts
    {
        [MethodImpl(Inline), Op]
        public static DataLayout define(LayoutIdentity id, LayoutPart[] segments)
            => new DataLayout(id, segments);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DataLayout<T> define<T>(LayoutIdentity<T> id, LayoutPart<T>[] segments)
            where T : unmanaged
                => new DataLayout<T>(id, segments);
    }
}