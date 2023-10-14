//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct BitPatterns
{
    public static string bitstring(in BpDef src, ulong value)
    {
        var segments = segs(src.Pattern);
        var count = (int)segments.Count;
        Span<char> buffer = stackalloc char[src.Pattern.PatternLength];
        var j=0u;
        for(var i=0; i<count; i++)
        {
            ref readonly var seg = ref segments[i];
            var bits = math.srl(seg.Mask.Apply(value), (byte)seg.MinPos);
            BitRender.render((ushort)bits, ref j, seg.Width, buffer);
            seek(buffer, j++) = Chars.Space;
        }
        return new string(buffer);
    }

    public static string bitstring<T>(in BpDef def, T value)
        where T : unmanaged
            => bitstring(def, bw64(value));

    public static string bitstring<P,T>(in BpDef<P> def, T value)
        where P : unmanaged, IBpDef<P>
        where T : unmanaged
            => bitstring(def.Untyped, bw64(value));
}
