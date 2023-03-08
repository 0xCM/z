//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Vars;

    public class TextExpr
    {
        protected Dictionary<string,IVar> VarLookup;

        public string Body {get;}


        public TextExpr(string body)
        {
            Body = body;
        }

        public IVar this[string var]
        {
            [MethodImpl(Inline)]
            get => VarLookup[var];

            [MethodImpl(Inline)]
            set => VarLookup[var] = value;
        }

        public ICollection<IVar> Vars
        {
            [MethodImpl(Inline)]
            get => VarLookup.Values;
        }

        public virtual string Eval()
            => api.eval(Body, Vars);
    }
}