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

        public readonly Index<RuleIdentity> Rules;

        [MethodImpl(Inline)]
        public SeqDef(asci32 name, SeqEffect effect, RuleName[] rules, RuleTableKind kind )
        {
            SeqName = name;
            Effect = effect;
            Rules = rules.Map(r => new RuleIdentity(kind,r));
        }

        _FileUri Uri(RuleIdentity src)
            => XedPaths.RuleTable(src);

        public string Format()
        {
            var dst = text.buffer();
            dst.AppendLineFormat("{0}(){{", SeqName);
            for(var i=0; i<Rules.Count; i++)
                dst.IndentLineFormat(4, "{0,-42} {1}",
                    Effect == 0 ? Rules[i].TableName : string.Format("{0}_{1}", Rules[i].TableName, Effect),
                    Uri(Rules[i])
                    );
            dst.AppendLine("}");
            return dst.Emit();
        }

        public override string ToString()
            => Format();
    }
}
