//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Rules;

    public class Production<S,T> : Rule, IProduction<S,T>
        where S : IRuleExpr
        where T : IRuleExpr
    {
        public S Source {get;}

        public T Target {get;}

        [MethodImpl(Inline)]
        public Production(S src, T dst)
        {
            Source = src;
            Target = dst;
        }

        public override string Format()
            => string.Format("{0} -> {1}", Source, Target);
    }

}