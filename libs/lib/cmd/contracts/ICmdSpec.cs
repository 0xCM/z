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
    }

    [Free]
    public interface ICmd<T> : ICmd
        where T : ICmd<T>, new()
    {
        CmdId ICmd.CmdId
            => Cmd.identify<T>();

        string IExpr.Format()
            => Cmd.format(this);
    }
}