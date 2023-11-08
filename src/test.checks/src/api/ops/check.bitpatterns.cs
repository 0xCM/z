//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

partial class ApiOps
{
    [CmdOp("check/bitpatterns")]
    void CheckBitPatterns(CmdArgs args)
    {
        const uint Prefix = 0x62f27d48u;

        var pattern = AsmBitPatterns.Evex;
        var segs =  pattern.Segs;
        var dst = text.emitter();
        var count = segs.Count;
        for(var i=0; i<count; i++)
        {
            ref readonly var seg = ref segs[i];
            dst.AppendLine($"{i:D2} {seg.SegName, -8} {seg.Mask} {seg.Interval.Format()}");
        }

        dst.AppendLine(BitPatterns.symbolic(pattern.Def));
        Channel.Row(dst.Emit());

        //dst.AppendLine(BitPatterns.bitstring(pattern.Expr, Prefix));
        
    }
}