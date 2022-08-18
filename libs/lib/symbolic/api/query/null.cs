//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;

    using C = AsciCode;
    using S = AsciSymbol;

    partial struct SymbolicQuery
    {
        /// <summary>
        /// Returns true if the source represents the null terminator
        /// </summary>
        /// <param name="src">The character to evaluate</param>
        [MethodImpl(Inline), Op]
        public static bit @null(C src)
            => src == C.Null;

        /// <summary>
        /// Returns true if the source is the null terminator
        /// </summary>
        /// <param name="src">The character to evaluate</param>
        [MethodImpl(Inline), Op]
        public static bit @null(char src)
            => src == (char)C.Null;

        [MethodImpl(Inline), Op]
        public static bit @null(ReadOnlySpan<C> src)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                if(!@null(skip(src,i)))
                    return false;
            }
            return true;
        }
    }
}