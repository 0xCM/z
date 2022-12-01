//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Commands.Commands;

    [Free]
    public interface ICmd<T> : ICmd
        where T : ICmd<T>, new()
    {
        CmdId ICmd.CmdId
            => CmdId.identify<T>();

        string IExpr.Format()
            => api.format((T)this);
    }    
}