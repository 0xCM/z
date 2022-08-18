//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IExprDeprecated : IExpr
    {
        ulong Kind => 0;

        bool INullity.IsEmpty
            => false;

       string IExpr.Format()
            => string.Empty;
    }
}