//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Rules;

    public sealed class Production : Production<IRuleExpr, IRuleExpr>, INullity, IProduction
    {
        [MethodImpl(Inline)]
        public Production(IRuleExpr src, IRuleExpr dst)
            : base(src, dst)
        {

        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Source.IsEmpty && Target.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Source.IsNonEmpty || Target.IsNonEmpty;
        }

        public override string Format()
        {
            if(Source.IsNonEmpty && Target.IsNonEmpty)
                return string.Format("{0} -> {1}", Source, Target);
            else if(Source.IsNonEmpty)
                return Source.Format();
            else if(Target.IsNonEmpty)
                return Target.Format();
            else
                return EmptyString;
        }

        public override string ToString()
            => Format();
    }

}