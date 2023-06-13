//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct SymbolicQuery
    {
        [Op]
        public static ReadOnlySpan<char> inside(ReadOnlySpan<char> src, int i, int j)
        {
            if(src.Length == 0 || j<=i)
                return EmptyString;
            else
                return sys.slice(src, i+1, (j-i) - 1);
        }

    }
}