//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Vars;

    public class TextExpr
    {
        protected Dictionary<string,ITextVar> VarLookup;

        public string Body {get;}

        public ITextVarExpr VarExpr {get;}

        public TextExpr(string body, ITextVarExpr exr)
        {
            Body = body;
            VarExpr = exr;
        }

        public ITextVar this[string var]
        {
            [MethodImpl(Inline)]
            get => VarLookup[var];

            [MethodImpl(Inline)]
            set => VarLookup[var] = value;
        }

        public ICollection<ITextVar> Vars
        {
            [MethodImpl(Inline)]
            get => VarLookup.Values;
        }

        public virtual string Eval()
        {
            switch(VarExpr.Class)
            {
                case ScriptVarClass.PrefixedFence:
                    return api.EvalPrefixFencedVarExpr(Body, Vars, VarExpr);
                case ScriptVarClass.Fenced:
                    return api.EvalFencedVarExpr(Body, Vars, VarExpr);
                case ScriptVarClass.Prefixed:
                    return api.EvalPrefixedVarExpr(Body, Vars, VarExpr);
            }
            return EmptyString;
        }
    }
}