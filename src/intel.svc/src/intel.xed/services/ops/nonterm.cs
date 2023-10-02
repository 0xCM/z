//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;
using static XedModels;

partial class Xed
{
    [MethodImpl(Inline), Op]
    public static bool nonterm(in PatternOp src, out Nonterminal dst)
    {
        var result = XedPatterns.first(src.Attribs, OpAttribKind.Nonterminal, out var attrib);
        if(result)
            dst = attrib.ToNonTerm();
        else
            dst = Nonterminal.Empty;
        return result;
    }
}
