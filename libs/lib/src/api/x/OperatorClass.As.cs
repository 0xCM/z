//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XApi
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static OperatorClass<T> As<T>(this OperatorClass src)
            where T : unmanaged => default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static UnaryOperatorClass<T> As<T>(this UnaryOperatorClass src)
            where T : unmanaged => default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static TernaryOperatorClass<T> As<T>(this TernaryOperatorClass src)
            where T : unmanaged => default;

        public static OperatorClass<W> Fixed<W>(this OperatorClass src)
            where W : unmanaged, ITypeWidth => default;

        public static UnaryOperatorClass<W> Fixed<W>(this UnaryOperatorClass src)
            where W : unmanaged, ITypeWidth => default;

        public static TernaryOperatorClass<W> Fixed<W>(this TernaryOperatorClass src)
            where W : unmanaged, ITypeWidth => default;
    }
}