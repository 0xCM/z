//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;

partial class XedRules
{
    public readonly struct SeqDef
    {
        public readonly asci32 SeqName;

        public readonly SeqEffect Effect;

        public readonly ReadOnlySeq<RuleIdentity> Steps;

        [MethodImpl(Inline)]
        public SeqDef(asci32 name, SeqEffect effect, RuleName[] rules, RuleTableKind kind )
        {
            SeqName = name;
            Effect = effect;
            Steps = rules.Map(r => new RuleIdentity(kind,r));
        }

        _FileUri Uri(RuleIdentity src)
            => XedPaths.RuleTable(src);

        public string Format()
        {
            var dst = text.buffer();
            dst.AppendLineFormat("{0}(){{", SeqName);
            for(var i=0; i<Steps.Count; i++)
                dst.IndentLineFormat(4, "{0,-42} {1}",
                    Effect == 0 ? Steps[i].TableName : string.Format("{0}_{1}", Steps[i].TableName, Effect),
                    Uri(Steps[i])
                    );
            dst.AppendLine("}");
            return dst.Emit();
        }

        public override string ToString()
            => Format();
    }
}
