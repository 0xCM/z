//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XTend
    {
        public static Index<T> Append<T>(this Span<T> head, ReadOnlySpan<T> tail)
        {
            var count = head.Length + tail.Length;
            var dst = alloc<T>(count);
            var j=0;
            for(var i=0; i<head.Length; i++, j++)
                seek(dst,j) = skip(head,i);
            for(var i=0; i<tail.Length; i++, j++)
                seek(dst,j) = skip(tail,i);
            return dst;
        }

        public static Index<T> Append<T>(this Index<T> head, ReadOnlySpan<T> tail)
            => head.Edit.Append(tail);

        public static Index<T> Append<T>(this T[] head, ReadOnlySpan<T> tail)
            => span(head).Append(tail);
    }
}