//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public Index<MacroDef> CalcMacroDefs()
        {
            var src = RuleMacros.specs();
            var count = src.Length;
            var buffer = alloc<MacroDef>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var m = ref src[i];
                var expansions = m.Expansions;
                var j=0;
                var k = m.Expansions.Count;
                ref var dst = ref seek(buffer,i);
                dst.Seq = i;
                dst.Fields = (byte)expansions.Count;
                dst.MacroName = m.Name;
                if(k >= 1)
                {
                    var e = expansions[j++];
                    dst.E0 = new MacroExpansion(e.Field, e.Operator, e.Value);
                }
                if(k >= 2)
                {
                    var e = expansions[j++];
                    dst.E1 = new MacroExpansion(e.Field, e.Operator, e.Value);
                }
                if(k >= 3)
                {
                    var e = expansions[j++];
                    dst.E2 = new MacroExpansion(e.Field, e.Operator, e.Value);
                }
                if(k >= 4)
                {
                    var e = expansions[j++];
                    dst.E3 = new MacroExpansion(e.Field, e.Operator, e.Value);

                }
                if(k >= 5)
                {
                    var e = expansions[j++];
                    dst.E4 = new MacroExpansion(e.Field, e.Operator, e.Value);
                }
            }

            return buffer;
        }
    }
}