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
        [Op, Closures(Closure)]
        public static DataLayout untyped<T>(DataLayout<T> src)
            where T : unmanaged
                => new DataLayout(src.Id, src.Storage.Map(x => untyped(x)));

        [Op, Closures(Closure)]
        public static DataLayout untyped<T,R>(DataLayout<T,R> src)
            where T : unmanaged
            where R : unmanaged
                => new DataLayout(src.Id, src.Storage.Map(x => untyped(x)));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static LayoutPart untyped<T>(in LayoutPart<T> src)
            where T : unmanaged
                => new LayoutPart(src.Id, src.Left, src.Right);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static LayoutPart untyped<T,R>(in LayoutPart<T,R> src)
            where T : unmanaged
            where R : unmanaged
                => new LayoutPart(src.Id, @as<R,ulong>(src.Left), @as<R,ulong>(src.Right));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static LayoutIdentity untyped<T>(in LayoutIdentity<T> src)
            where T : unmanaged
                => new LayoutIdentity(src.Index, @as<T,uint>(src.Kind));
    }
}