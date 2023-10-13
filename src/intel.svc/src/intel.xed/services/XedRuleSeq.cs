//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedRules;
using static XedModels;

[ApiHost,Free]
public unsafe partial class XedRuleSeq
{
    [MethodImpl(Inline), Op]
    public static SeqDef bind(asci32 name, RuleName[] rules)
        => new (name, SeqEffect.BIND, rules, RuleTableKind.ENC);

    [MethodImpl(Inline), Op]
    public static SeqDef emit(asci32 name, RuleName[] rules)
        => new (name, SeqEffect.EMIT, rules, RuleTableKind.ENC);

    [MethodImpl(Inline), Op]
    public static SeqDef def(asci32 name, RuleTableKind kind, params RuleName[] rules)
        => new (name, SeqEffect.None, rules, kind);

    [MethodImpl(Inline), Op]
    public static SeqControl control(asci32 name, params SeqDef[] src)
        => new (name, src);

    public static Index<SeqDef> defs()
    {
        var src = typeof(XedRuleSeq).StaticMethods().Public().WithArity(0).Where(x => x.ReturnType == typeof(SeqDef));
        var dst = alloc<SeqDef>(src.Length);
        for(var i=0; i<src.Length; i++)
            seek(dst,i) = (SeqDef)skip(src,i).Invoke(null, null);
        return dst;
    }

    public static Index<SeqControl> controls()
    {
        var src = typeof(XedRuleSeq).StaticMethods().Public().WithArity(0).Where(x => x.ReturnType == typeof(SeqControl));
        var dst = alloc<SeqControl>(src.Length);
        for(var i=0; i<src.Length; i++)
            seek(dst,i) = (SeqControl)skip(src,i).Invoke(null, null);
        return dst;
    }
}
