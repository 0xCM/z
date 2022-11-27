//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Storage
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly GBlock2<T> store<T>(in GBlock2<T> src, Span<T> dst)
            where T : unmanaged
        {
            first(recover<T,GBlock2<T>>(dst)) = src;
            return ref src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly GBlock3<T> store<T>(in GBlock3<T> src, Span<T> dst)
            where T : unmanaged
        {
            first(recover<T,GBlock3<T>>(dst)) = src;
            return ref src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly GBlock4<T> store<T>(in GBlock4<T> src, Span<T> dst)
            where T : unmanaged
        {
            first(recover<T,GBlock4<T>>(dst)) = src;
            return ref src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly GBlock5<T> store<T>(in GBlock5<T> src, Span<T> dst)
            where T : unmanaged
        {
            first(recover<T,GBlock5<T>>(dst)) = src;
            return ref src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly GBlock6<T> store<T>(in GBlock6<T> src, Span<T> dst)
            where T : unmanaged
        {
            first(recover<T,GBlock6<T>>(dst)) = src;
            return ref src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly GBlock7<T> store<T>(in GBlock7<T> src, Span<T> dst)
            where T : unmanaged
        {
            first(recover<T,GBlock7<T>>(dst)) = src;
            return ref src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly GBlock8<T> store<T>(in GBlock8<T> src, Span<T> dst)
            where T : unmanaged
        {
            first(recover<T,GBlock8<T>>(dst)) = src;
            return ref src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly GBlock12<T> store<T>(in GBlock12<T> src, Span<T> dst)
            where T : unmanaged
        {
            first(recover<T,GBlock12<T>>(dst)) = src;
            return ref src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly GBlock16<T> store<T>(in GBlock16<T> src, Span<T> dst)
            where T : unmanaged
        {
            first(recover<T,GBlock16<T>>(dst)) = src;
            return ref src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly GBlock32<T> store<T>(in GBlock32<T> src, Span<T> dst)
            where T : unmanaged
        {
            first(recover<T,GBlock32<T>>(dst)) = src;
            return ref src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly GBlock64<T> store<T>(in GBlock64<T> src, Span<T> dst)
            where T : unmanaged
        {
            first(recover<T,GBlock64<T>>(dst)) = src;
            return ref src;
        }
    }
}