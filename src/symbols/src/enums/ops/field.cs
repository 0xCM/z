//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Enums
    {
        [MethodImpl(Inline)]
        public static ClrEnumMember<E> field<E>(uint index, FieldInfo src, E value)
            where E : unmanaged, Enum
                => new (index,src,value);
    }
}