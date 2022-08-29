//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ICmd : IExpr
    {
        CmdId CmdId {get;}

        bool INullity.IsEmpty
            => CmdId.IsEmpty;

        bool INullity.IsNonEmpty
            => CmdId.IsNonEmpty;
    }
}