//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Algs
    {
        [MethodImpl(Inline), Op]
        public static unsafe ReadOnlySpan<char> chars(string src)
            => Algs.cover(memory.pchar(src), (uint)src.Length);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<char> chars<E>(ReadOnlySpan<E> src)
            where E : unmanaged
                => Spans.recover<E,char>(src);
    }
}