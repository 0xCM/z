//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class TextBlockExpr : TextExpr
    {
        public TextBlockExpr(string body, ITextVarExpr varkind)
            : base(body,varkind)
        {
            VarLookup = new();
        }
    }
}