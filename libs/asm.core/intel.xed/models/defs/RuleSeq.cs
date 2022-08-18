//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct RuleSeq
        {
            public readonly Identifier Name;

            public readonly Index<RuleSeqTerm> Terms;

            [MethodImpl(Inline)]
            public RuleSeq(Identifier name, params RuleSeqTerm[] terms)
            {
                Name = name;
                Terms = terms;
            }

            public string Format()
            {
                var dst = text.buffer();
                dst.AppendLineFormat("SEQUENCE {0}", Name);
                for(var i=0; i<Terms.Count; i++)
                {
                    dst.IndentLine(4, Terms[i].Format());
                }
                return dst.Emit();
            }

            public override string ToString()
                => Format();

            public static RuleSeq Empty => new RuleSeq(EmptyString, sys.empty<RuleSeqTerm>());
        }
    }
}