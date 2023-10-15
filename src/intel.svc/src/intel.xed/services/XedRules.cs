//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;

[ApiHost]
public partial class XedRules : WfSvc<XedRules>
{
    const string xed = "xed";

    const NumericKind Closure = UnsignedInts;

    [MethodImpl(Inline)]
    public static RuleIdentity enc(RuleName name)
        => new(RuleTableKind.ENC,name);

    [MethodImpl(Inline)]
    public static RuleIdentity dec(RuleName name)
        => new(RuleTableKind.DEC,name);    
}
