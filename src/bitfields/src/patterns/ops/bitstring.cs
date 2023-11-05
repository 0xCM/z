//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct BitPatterns
{
    public static string bitstring(BpExpr src, ulong value)
    {
        var segments = segdefs(src);
        var count = (int)segments.Count;
        Span<char> buffer = stackalloc char[src.PatternLength];
        var j=0u;
        for(var i=0; i<count; i++)
        {
            ref readonly var seg = ref segments[i];
            var bits = math.srl(seg.Mask.Apply(value), (byte)seg.MinPos);
            if(i != 0)
                seek(buffer, j++) = Chars.Space;
            BitRender.render((ushort)bits, ref j, seg.Width, buffer);
        }
        return new string(buffer);
    }

    public static string bitstring<T>(BpExpr pattern, T value)
        where T : unmanaged
            => bitstring(pattern, bw64(value));
}
