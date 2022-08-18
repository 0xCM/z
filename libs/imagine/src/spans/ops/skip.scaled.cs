//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;
    using static Algs;

    partial class Spans
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly byte skip8<T>(ReadOnlySpan<T> src, long count)
            => ref add(@as<T,byte>(first(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly byte skip8<T>(ReadOnlySpan<T> src, ulong count)
            => ref add(@as<T,byte>(first(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly sbyte skip8i<T>(ReadOnlySpan<T> src, long count)
            => ref add(@as<T,sbyte>(first(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly sbyte skip8i<T>(ReadOnlySpan<T> src, ulong count)
            => ref add(@as<T,sbyte>(first(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly ushort skip16<T>(ReadOnlySpan<T> src, ulong count)
           => ref Add(ref As<T,ushort>(ref Algs.edit(first(src))), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly short skip16i<T>(ReadOnlySpan<T> src, long count)
           => ref Add(ref As<T,short>(ref Algs.edit(first(src))), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly ulong skip64<T>(ReadOnlySpan<T> src, ulong count)
            => ref Add(ref As<T,ulong>(ref Algs.edit(first(src))), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly short skip16i<T>(ReadOnlySpan<T> src, ulong count)
           => ref Add(ref As<T,short>(ref Algs.edit(first(src))), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly long skip64i<T>(ReadOnlySpan<T> src, long count)
            => ref Add(ref As<T,long>(ref Algs.edit(first(src))), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly long skip64i<T>(ReadOnlySpan<T> src, ulong count)
            => ref Add(ref As<T,long>(ref Algs.edit(first(src))), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly int skip32i<T>(ReadOnlySpan<T> src, long count)
            => ref Add(ref As<T,int>(ref Algs.edit(first(src))), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly int skip32i<T>(ReadOnlySpan<T> src, ulong count)
            => ref Add(ref As<T,int>(ref Algs.edit(first(src))), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly uint skip32<T>(ReadOnlySpan<T> src, ulong count)
            => ref Add(ref As<T,uint>(ref Algs.edit(first(src))), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly ulong skip64<T>(ReadOnlySpan<T> src, long count)
            => ref Add(ref As<T,ulong>(ref Algs.edit(first(src))), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly uint skip32<T>(ReadOnlySpan<T> src, long count)
            => ref Add(ref As<T,uint>(ref Algs.edit(first(src))), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly ushort skip16<T>(ReadOnlySpan<T> src, long count)
           => ref Add(ref As<T,ushort>(ref Algs.edit(first(src))), (int)count);
    }
}