//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly record struct NontermCall : IComparable<NontermCall>
        {
            public readonly RuleCaller Source;

            public readonly RuleSig Target;

            [MethodImpl(Inline)]
            public NontermCall(RuleSig src, RuleSig dst)
            {
                Source = src;
                Target = dst;
            }

            public int CompareTo(NontermCall src)
            {
                var result = Source.CompareTo(src.Source);
                if(result == 0)
                    result = Target.CompareTo(src.Target);
                return result;
            }

            public string Format()
                => string.Format("{0} -> {1}", Source.ToRule().TableName, Target.TableName);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator NontermCall<RuleSig>(NontermCall src)
                => new NontermCall<RuleSig>(src.Source.ToRule(), src.Target);

            [MethodImpl(Inline)]
            public static implicit operator NontermCall(NontermCall<RuleSig> src)
                => new NontermCall(src.Source, src.Target);
        }
    }
}