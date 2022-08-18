//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Numeric
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool unsigned<T>()
            => typeof(T) == typeof(byte) || typeof(T) == typeof(ushort) || typeof(T) == typeof(uint) || typeof(T) == typeof(ulong);

        [MethodImpl(Inline), Op]
        public static bool unsigned(Type src)
            => src == typeof(byte) || src == typeof(ushort) || src == typeof(uint) || src == typeof(ulong);
    }
}