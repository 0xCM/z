//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct Symbols
{
    [MethodImpl(Inline)]
    public static FieldInfo[] fields(Type src)
        => src.LiteralFields();

    [MethodImpl(Inline)]
    public static FieldInfo[] fields<E>()
        where E : unmanaged
            => fields(typeof(E));
}