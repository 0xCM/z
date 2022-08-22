//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using C = AsciCode;
    using S = AsciSymbol;

    partial struct SymbolicQuery
    {
        /// <summary>
        /// Returns the index of the first whitespace character, if any, beginning at a specified offset
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="offset">The offset at which to begin searching</param>
        [MethodImpl(Inline), Op]
        public static int wsix(ReadOnlySpan<char> src, uint offset = 0)
        {
            var i0 = min((int)offset,src.Length);
            if(i0 < offset)
                return NotFound;

            for(var i=i0; i< src.Length; i++)
                if(whitespace(skip(src,i)))
                    return i;

            return NotFound;
        }

        [MethodImpl(Inline), Op]
        public static int wsix(ReadOnlySpan<C> src, uint offset)
        {
            var i0 = min((int)offset,src.Length);
            if(i0 < offset)
                return NotFound;

            for(var i=i0; i< src.Length; i++)
                if(whitespace(skip(src,i)))
                    return i;

            return NotFound;
        }

        [MethodImpl(Inline), Op]
        public static int wsix(ReadOnlySpan<S> src, uint offset)
            => wsix(recover<S,C>(src), offset);
    }
}