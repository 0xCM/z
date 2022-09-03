//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Numeric
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool signed<T>()
            => typeof(T) == typeof(sbyte) || typeof(T) == typeof(short) || typeof(T) == typeof(int) || typeof(T) == typeof(long);

        [MethodImpl(Inline), Op]
        public static bool signed(Type src)
            => src == typeof(sbyte) || src == typeof(short) || src == typeof(int) || src == typeof(long);
    }
}