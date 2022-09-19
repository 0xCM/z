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
        // public RuleTables CalcRuleTables()
        // {
        //     var dst = new RuleTables();
        //     var buffers = dst.CreateBuffers();
        //     exec(PllExec,
        //         () => buffers.Criteria.TryAdd(RuleTableKind.ENC, RuleSpecs.criteria(RuleTableKind.ENC)),
        //         () => buffers.Criteria.TryAdd(RuleTableKind.DEC, RuleSpecs.criteria(RuleTableKind.DEC))
        //         );

        //     dst.Seal(buffers, PllExec);
        //     return dst;
        // }
   }
}