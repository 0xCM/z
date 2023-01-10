//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Vars;
    
    public class PatternTextExpr : TextExpr
    {
        [MethodImpl(Inline), Op]
        public static PatternTextExpr init(string body)
            => new PatternTextExpr(body);

        public PatternTextExpr(string body)
            : base(body, TextVar.Kind)
        {
            VarLookup = api.ParseFencedVars(body, TextVar.Kind, name => new TextVar(name));
        }
    }
}