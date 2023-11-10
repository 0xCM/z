//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedRules.WidthVar;
    using static sys;

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
            {
                ref var target = ref seek(vars,i);
                ref readonly var w = ref skip(widths,i);
                ref readonly var k = ref skip(kinds,i);
                ref readonly var n = ref skip(names,i);
                target = new WidthVar(n, k, w);
                Require.equal((uint)w, (uint)target.Value);
                Require.equal((uint)k, (uint)target.Sort);
                Require.equal((uint)n, (uint)target.Name);

            }

            for(var i=0; i<Count; i++)
            {
                ref readonly var v = ref skip(vars,i);
                ref readonly var expect = ref skip(expr,i);
                var formatted = v.Format();
                if(formatted != expect)
                {
                    @throw($"format({v.Value}:({v.Name}:{v.Sort}) = '{formatted}' != '{expect}'");                    
                }

                Require.equal(formatted, expect);
            }

            for(var i=0; i<Count; i++)
            {
                ref readonly var input = ref skip(expr,i);
                parse(input, out WidthVar wv);
                ref readonly var expect = ref skip(vars,i);
                if(wv != expect)
                {
                    @throw($"parse('{input}') = '{wv}' != '{expect}'");
                }
            }
            return true;
        }
    }
}