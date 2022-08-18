//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct DataLayouts
    {
        [MethodImpl(Inline), Op]
        public static DataLayout specify(uint index, ulong kind, params LayoutPart[] parts)
            => new DataLayout(identify(index, kind), parts);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DataLayout<T> specify<T>(uint index, T kind, params LayoutPart<T>[] parts)
            where T : unmanaged
                => new DataLayout<T>(identify(index, kind), parts);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DataLayout<T> specify<T>(uint index, LayoutIdentity<T> id, params LayoutPart<T>[] parts)
            where T : unmanaged
                => new DataLayout<T>(id, parts);

        [Op, Closures(Closure)]
        public static DataLayout<T> specify<T>(uint index, T kind, uint count)
            where T : unmanaged
                => new DataLayout<T>(identify(index, kind), alloc<LayoutPart<T>>(count));
    }
}