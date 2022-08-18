//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class strings
    {
        const NumericKind Closure = UnsignedInts;

        [Op]
        public static ReadOnlySpan<AsciCode> unfence(ReadOnlySpan<AsciCode> src, Fence<AsciCode> fence)
        {
            (var i0, var i1) = SQ.indices(src, fence);
            if(i0 != NotFound && i1 != NotFound && (i0 < i1))
            {
                var start = i0 + 1;
                var length = i1 - start;
                return Spans.slice(src, start, length);
            }
            else
                return ReadOnlySpan<AsciCode>.Empty;
        }
    }

    public class Strings
    {
        const NumericKind Closure = UnsignedInts;
    }

    public abstract class Strings<T>
        where T : IString
    {

    }
}