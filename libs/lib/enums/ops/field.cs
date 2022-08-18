//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Enums
    {
        [MethodImpl(Inline)]
        public static ClrEnumFieldAdapter<E> field<E>(uint index, FieldInfo src, E value)
            where E : unmanaged, Enum
                => new ClrEnumFieldAdapter<E>(index,src,value);
    }
}