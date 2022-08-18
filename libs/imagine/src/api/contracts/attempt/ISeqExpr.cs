//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ISeqExpr<T> : IExpr
        where T : IExpr
    {
        ReadOnlySpan<T> Terms {get;}

        string IExpr.Format()
            => String.Join(" ", Terms.MapArray(t => t.ToString()));

        bool INullity.IsEmpty
            => Terms.IsEmpty;
    }
}