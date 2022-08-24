//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using M = EnumFormatMode;

    public readonly struct EnumFormat
    {
        [MethodImpl(Inline)]
        public static EnumFormat<E> name<E>(E src, bool ez = true)
            where E : unmanaged, Enum
                => new EnumFormat<E>(src, M.Name | (ez ? M.EmptyZero : M.Default));

        [MethodImpl(Inline)]
        public static EnumFormat<E> expr<E>(E src, bool ez = true)
            where E : unmanaged, Enum
                => new EnumFormat<E>(src, M.Expr | (ez ? M.EmptyZero : M.Default));

        [MethodImpl(Inline)]
        public static EnumFormat<E> scalar<E>(E src, bool ez = false)
            where E : unmanaged, Enum
                => new EnumFormat<E>(src, M.Expr | (ez ? M.EmptyZero : M.Default));
    }
}