//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct BitPatterns
{
    public static string bitstring(BpExpr expr, ulong src)
    {
        var segments = segdefs(expr);
        Span<char> buffer = stackalloc char[expr.PatternLength];
        var j=0u;
        for(var i=0; i<segments.Count; i++)
        {
            if(i != 0)
                seek(buffer, j++) = Chars.Space;            
            segbits(segments[i], src, ref j, buffer);
        }
        return new string(buffer);
    }

    public static string bitstring<T>(BpExpr pattern, T value)
        where T : unmanaged
            => bitstring(pattern, bw64(value));
}
