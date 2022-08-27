//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ITableId : IExpr
    {
        Identifier Identifier {get;}

        string IExpr.Format()
            => Identifier.Format();

        bool INullity.IsEmpty
            => Identifier.IsEmpty;

        bool INullity.IsNonEmpty
            => Identifier.IsNonEmpty;
    }
}