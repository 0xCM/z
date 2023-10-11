//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    public readonly record struct NontermCall<T> : IArrow<T,RuleIdentity>, IComparable<NontermCall<T>>
        where T : unmanaged, IComparable<T>
    {
        public readonly T Source;

        public readonly RuleIdentity Target;

        [MethodImpl(Inline)]
        public NontermCall(T src, RuleIdentity dst)
        {
            Source = src;
            Target = dst;
        }

        public int CompareTo(NontermCall<T> src)
        {
            var result = Source.CompareTo(src.Source);
            if(result == 0)
                result = Target.CompareTo(src.Target);
            return result;
        }

        public string Format()
            => string.Format("{0} -> {1}",
                (Source is RuleIdentity s ? s.TableName.ToString() : Source.ToString()) ,
                Target.TableName);

        public override string ToString()
            => Format();

        T IArrow<T,RuleIdentity>.Source
            => Source;

        RuleIdentity IArrow<T,RuleIdentity>.Target
            => Target;
    }
}
