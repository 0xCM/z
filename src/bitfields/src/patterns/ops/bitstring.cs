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
        var segments = segs(src);
        var count = (int)segments.Count;
        Span<char> buffer = stackalloc char[src.PatternLength];
        var j=0u;
        for(var i=count-1; i>=0; i--)
        {
            ref readonly var seg = ref segments[i];
            var bits = math.srl(seg.Mask.Apply(value), (byte)seg.MinPos);
            BitRender.render((ushort)bits, ref j, seg.Width, buffer);
            seek(buffer, j++) = Chars.Space;
        }
        return new string(buffer);
    }

    public static string bitstring<T>(BpExpr pattern, T value)
        where T : unmanaged
            => bitstring(pattern, bw64(value));
}
