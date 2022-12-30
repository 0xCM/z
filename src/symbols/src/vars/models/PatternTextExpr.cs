//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class PatternTextExpr : TextExpr
    {
        [MethodImpl(Inline), Op]
        public static PatternTextExpr init(string body)
            => new PatternTextExpr(body);

        public PatternTextExpr(string body)
            : base(body, PatternTextVar.Kind)
        {
            VarLookup = ParseFencedVars(body, PatternTextVar.Kind, name => new PatternTextVar(name));
        }
    }
}