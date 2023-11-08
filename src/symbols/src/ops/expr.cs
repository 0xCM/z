//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Symbols
    {
        public static SymExpr expr<E>(E src)
            where E : unmanaged, Enum
        {
            var ix = index<E>();
            if(ix.FindByKind(src, out var sym))
                return sym.Expr;
            else
                return src.ToString();
        }
    }
}