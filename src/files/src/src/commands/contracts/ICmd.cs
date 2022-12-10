//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Commands.Commands;

    [Free]
    public interface IApiCmd : ICmd
    {
        string CmdName {get;}            
    }


    [Free]
    public interface IApiCmd<T> : IApiCmd
        where T : IApiCmd<T>, new()
    {
        CmdId ICmd.CmdId
            => CmdId.identify<T>();

        string IExpr.Format()
            => api.format((T)this);

        string IApiCmd.CmdName
            => CmdId.identify<T>().Format();
    }    
}