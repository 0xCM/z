//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedRules.WidthVar;
    using static core;

    using L = XedRules.WidthVar.Label;

    partial class XedChecks
    {
        [CmdOp("xed/check/widths")]
        Outcome CheckWidths(CmdArgs args)
        {
            const byte Count = 16;
            var expr = new string[Count]{
                "d/8", "d/16", "d/32", "d/64",
                "a/8", "a/16", "a/32", "a/64",
                "i/8", "i/16", "i/32", "i/64",
                "i/8", "i/16", "i/32", "i/64",
                };

            var kinds = new Kind[Count]{
                Kind.Disp, Kind.Disp, Kind.Disp, Kind.Disp,
                Kind.MemDisp, Kind.MemDisp, Kind.MemDisp, Kind.MemDisp,
                Kind.Imm, Kind.Imm, Kind.Imm, Kind.Imm,
                Kind.Imm, Kind.Imm, Kind.Imm, Kind.Imm,
            };

            var widths = new Width[Count]{
                Width.W8, Width.W16, Width.W32, Width.W64,
                Width.W8, Width.W16, Width.W32, Width.W64,
                Width.W8, Width.W16, Width.W32, Width.W64,
                Width.W8, Width.W16, Width.W32, Width.W64,
            };

            var names = new L[Count]{
                L.DISP, L.DISP,L.DISP,L.DISP,
                L.DISP, L.DISP,L.DISP,L.DISP,
                L.UIMM0, L.UIMM0, L.UIMM0, L.UIMM0,
                L.UIMM1, L.UIMM1, L.UIMM1, L.UIMM1,
            };

            var vars = alloc<WidthVar>(Count);
            for(var i=0; i<Count; i++)
                seek(vars,i) = new WidthVar(skip(names,i), skip(kinds,i), skip(widths,i));
            for(var i=0; i<Count; i++)
                Require.equal(skip(vars,i).Format(), skip(expr,i));
            for(var i=0; i<Count; i++)
            {
                parse(skip(expr,i), out WidthVar wv);
                Require.equal(wv, skip(vars,i));
            }
            return true;
        }
    }
}