//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    partial class Spans
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref sbyte seek8i<T>(Span<T> src, ulong count)
            => ref Add(ref As<T,sbyte>(ref first(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref byte seek8<T>(Span<T> src, ulong count)
            => ref Add(ref As<T,byte>(ref first(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref ushort seek16<T>(Span<T> src, ulong count)
            => ref Add(ref As<T,ushort>(ref first(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref short seek16i<T>(Span<T> src, ulong count)
            => ref Add(ref As<T,short>(ref first(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref uint seek32<T>(Span<T> src, ulong count)
            => ref Add(ref As<T,uint>(ref first(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref int seek32i<T>(Span<T> src, ulong count)
            => ref Add(ref As<T,int>(ref first(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref ulong seek64<T>(Span<T> src, ulong count)
            => ref Add(ref As<T,ulong>(ref first(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref long seek64i<T>(Span<T> src, ulong count)
            => ref Add(ref As<T,long>(ref first(src)), (int)count);
    }
}