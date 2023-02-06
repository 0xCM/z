//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Enums
    {
        [MethodImpl(Inline)]
        public static ClrEnumAdapter adapt(Type src)
            => new ClrEnumAdapter(src);

        [MethodImpl(Inline)]
        public static ClrEnumAdapter<E> adapt<E>()
            where E : unmanaged, Enum
                => default;
    }
}