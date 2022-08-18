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
        [MethodImpl(Inline), Op]
        public static int index(ReadOnlySpan<char> src, ReadOnlySpan<char> match, bool cased = true)
            => src.IndexOf(match, cased ? Cased : NoCase);

        [MethodImpl(Inline), Op]
        public static int index(ReadOnlySpan<char> src, int offset, char match)
        {
            for(var i=offset; i<src.Length; i++)
                if(skip(src, i) == match)
                    return i;
            return NotFound;
        }

        [MethodImpl(Inline), Op]
        public static bool index(ReadOnlySpan<char> src, char match, out int i)
        {
            i = index(src, match);
            return i >= 0;
        }

        [Op]
        public static int index(ReadOnlySpan<char> src, char c0, char c1)
        {
            var count = src.Length;
            var level = 0;
            var index = -1;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src, i);
                switch(level)
                {
                    case 0:
                        if(SQ.match(c, c0))
                            level++;
                    break;
                    case 1:
                        if(SQ.match(c, c1))
                        {
                            index = i-level;
                            break;
                        }
                    break;
                    default:
                        level = 0;
                        break;
                }
            }
            return index;
        }

        [MethodImpl(Inline), Op]
        public static int index(ReadOnlySpan<char> src, char match)
            => src.IndexOf(match);

        [MethodImpl(Inline), Op]
        public static int index(ReadOnlySpan<C> src, S match)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                if((char)skip(src,i) == match)
                    return i;
            return NotFound;
        }

        [MethodImpl(Inline), Op]
        public static int index(ReadOnlySpan<char> src, ReadOnlySpan<char> match)
            => src.IndexOf(match);

        [MethodImpl(Inline), Op]
        public static int index(ReadOnlySpan<char> src, int offset, ReadOnlySpan<char> match)
            => slice(src, 0, offset).IndexOf(match);
    }
}