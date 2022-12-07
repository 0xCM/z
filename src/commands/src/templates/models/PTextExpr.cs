//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class PTextExpr : TextExpr
    {
        [MethodImpl(Inline), Op]
        public static PTextExpr init(string body)
            => new PTextExpr(body);

        public PTextExpr(string body)
            : base(body, PTextVar.Kind)
        {
            VarLookup = ParseFencedVars(body, PTextVar.Kind, name => new PTextVar(name));
        }
    }
}