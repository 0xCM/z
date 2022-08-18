//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class gmath
    {
        [MethodImpl(Inline), False, Closures(Integers)]
        public static T @false<T>()
            where T:unmanaged
                => default;

        [MethodImpl(Inline), False, Closures(Integers)]
        public static T @false<T>(T a)
            where T:unmanaged
                => @false<T>();

        [MethodImpl(Inline), False, Closures(Integers)]
        public static T @false<T>(T a, T b, T c)
            where T:unmanaged
                => @false<T>();

        [MethodImpl(Inline), True, Closures(Integers)]
        public static T @true<T>()
            where T:unmanaged
                => core.ones<T>();

        [MethodImpl(Inline), True, Closures(Integers)]
        public static T @true<T>(T a)
            where T:unmanaged
                => @true<T>();

        [MethodImpl(Inline), True, Closures(Integers)]
        public static T @true<T>(T a, T b)
            where T:unmanaged
                => @true<T>();

        [MethodImpl(Inline), False, Closures(Integers)]
        public static T @false<T>(T a, T b)
            where T:unmanaged
                => @false<T>();

        [MethodImpl(Inline), True, Closures(Integers)]
        public static T @true<T>(T a, T b, T c)
            where T:unmanaged
                => @true<T>();
    }
}