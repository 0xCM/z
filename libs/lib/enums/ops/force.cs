//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Sized;

    partial struct Enums
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static byte force8u<E>(E src)
            where E : unmanaged
        {
            if(size<E>() == 1)
                return e8u(src);
            else if(size<E>() == 2)
                return (byte)e16u(src);
            else if(size<E>() == 4)
                return (byte)e32u(src);
            else
                return (byte)e64u(src);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ushort force16u<E>(E src)
            where E : unmanaged
        {
            if(size<E>() == 1)
                return e8u(src);
            else if(size<E>() == 2)
                return e16u(src);
            else if(size<E>() == 4)
                return (ushort)e32u(src);
            else
                return (ushort)e64u(src);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint force32u<E>(E src)
            where E : unmanaged
        {
            if(size<E>() == 1)
                return e8u(src);
            else if(size<E>() == 2)
                return e16u(src);
            else if(size<E>() == 4)
                return e32u(src);
            else
                return (uint)e64u(src);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ulong force64u<E>(E src)
            where E : unmanaged
        {
            if(size<E>() == 1)
                return e8u(src);
            else if(size<E>() == 2)
                return e16u(src);
            else if(size<E>() == 4)
                return e32u(src);
            else
                return e64u(src);
        }
    }
}