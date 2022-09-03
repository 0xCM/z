//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Enums
    {
        [MethodImpl(Inline), Op]
        public static Array values(Type src)
            => Enum.GetValues(src);

        [MethodImpl(Inline)]
        public static T[] values<T>()
            where T : unmanaged, Enum
                => Enum.GetValues<T>();
    }
}