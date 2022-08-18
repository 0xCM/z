//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IFreeCmpPred<H,T> : IFreeCmpPred<H>, IFreeExpr<H,CmpPredKind,T>, IKinded<CmpPredKind>
        where T : unmanaged
        where H : IFreeCmpPred<H,T>
    {

        T Left {get;}

        T Right {get;}

        string IExpr.Format()
            => string.Format("{0} {1} {2}", Left, Symbols.expr<CmpPredKind>(Kind), Right);
    }
}