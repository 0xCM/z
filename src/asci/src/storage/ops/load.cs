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
        public static ref GBlock2<T> load<T>(ReadOnlySpan<T> src, ref GBlock2<T> dst)
            where T : unmanaged
        {
            dst = first(recover<T,GBlock2<T>>(src));
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock3<T> load<T>(ReadOnlySpan<T> src, ref GBlock3<T> dst)
            where T : unmanaged
        {
            dst = first(recover<T,GBlock3<T>>(src));
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock4<T> load<T>(ReadOnlySpan<T> src, ref GBlock4<T> dst)
            where T : unmanaged
        {
            dst = first(recover<T,GBlock4<T>>(src));
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock5<T> load<T>(ReadOnlySpan<T> src, ref GBlock5<T> dst)
            where T : unmanaged
        {
            dst = first(recover<T,GBlock5<T>>(src));
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock6<T> load<T>(ReadOnlySpan<T> src, ref GBlock6<T> dst)
            where T : unmanaged
        {
            dst = first(recover<T,GBlock6<T>>(src));
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock7<T> load<T>(ReadOnlySpan<T> src, ref GBlock7<T> dst)
            where T : unmanaged
        {
            dst = first(recover<T,GBlock7<T>>(src));
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock8<T> load<T>(ReadOnlySpan<T> src, ref GBlock8<T> dst)
            where T : unmanaged
        {
            dst = first(recover<T,GBlock8<T>>(src));
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock12<T> load<T>(ReadOnlySpan<T> src, ref GBlock12<T> dst)
            where T : unmanaged
        {
            dst = first(recover<T,GBlock12<T>>(src));
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock16<T> load<T>(ReadOnlySpan<T> src, ref GBlock16<T> dst)
            where T : unmanaged
        {
            dst = first(recover<T,GBlock16<T>>(src));
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock32<T> load<T>(ReadOnlySpan<T> src, ref GBlock32<T> dst)
            where T : unmanaged
        {
            dst = first(recover<T,GBlock32<T>>(src));
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock64<T> load<T>(ReadOnlySpan<T> src, ref GBlock64<T> dst)
            where T : unmanaged
        {
            dst = first(recover<T,GBlock64<T>>(src));
            return ref dst;
        }

    }
}