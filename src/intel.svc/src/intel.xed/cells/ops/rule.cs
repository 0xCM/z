//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;
using static XedRules;

partial class XedCells
{
    public static Nonterminal rule(in InstCells src, RuleName name)
    {
        var dst = Nonterminal.Empty;
        for(var i=0; i<src.Count; i++)
        {
            ref readonly var cell = ref src[i];
            if(cell.IsNonterm)
            {
                var nt = cell.AsNonterm();
                if(nt.Name == name)
                {
                    dst = nt;
                    break;
                }
            }            
        }
        return dst;
    }
}