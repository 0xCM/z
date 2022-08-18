//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static Index<T> Append<T>(this Span<T> head, ReadOnlySpan<T> tail)
        {
            var count = head.Length + tail.Length;
            var dst = sys.alloc<T>(count);
            var j=0;
            for(var i=0; i<head.Length; i++, j++)
                Arrays.seek(dst,j) = Spans.skip(head,i);
            for(var i=0; i<tail.Length; i++, j++)
                Arrays.seek(dst,j) = Spans.skip(tail,i);
            return dst;
        }

        public static Index<T> Append<T>(this Index<T> head, ReadOnlySpan<T> tail)
            => head.Edit.Append(tail);

        public static Index<T> Append<T>(this T[] head, ReadOnlySpan<T> tail)
            => Spans.@span(head).Append(tail);
    }
}