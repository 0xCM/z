//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Enums
    {
        public static Index<T> numeric<E,T>()
            where E : unmanaged, Enum
            where T : unmanaged
                => typeof(E).Fields().Select(f => ClrLiterals.value<T>(f));

        [MethodImpl(Inline)]
        public static unsafe V numeric<E,V>(E src)
            where E : unmanaged, Enum
            where V : unmanaged
                => Unsafe.Read<V>((V*)(&src));
    }
}