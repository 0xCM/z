//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    public readonly record struct NontermCall<T> : IArrow<T,RuleSig>, IComparable<NontermCall<T>>
        where T : unmanaged, IComparable<T>
    {
        public readonly T Source;

        public readonly RuleSig Target;

        [MethodImpl(Inline)]
        public NontermCall(T src, RuleSig dst)
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
                (Source is RuleSig s ? s.TableName.ToString() : Source.ToString()) ,
                Target.TableName);

        public override string ToString()
            => Format();

        T IArrow<T,RuleSig>.Source
            => Source;

        RuleSig IArrow<T,RuleSig>.Target
            => Target;
    }
}
