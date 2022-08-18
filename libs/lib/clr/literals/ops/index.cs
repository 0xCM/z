//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ClrLiterals
    {
        [MethodImpl(Inline)]
        public static EnumValues<E,T> index<E,T>(EnumValue<E,T>[] src)
            where E : unmanaged, Enum
            where T : unmanaged
                => new EnumValues<E,T>(src);
    }
}