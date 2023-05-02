//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IApiCmd : ICmd
    {
        CmdUri Uri {get;}
    }

    [Free]
    public interface IApiCmd<T> : IApiCmd
        where T : IApiCmd<T>, new()
    {
        ApiCmdRoute Route
            => ApiCmdRoute.route(typeof(T));
        
        CmdId ICmd.CmdId
            => CmdId.identify<T>();

        string IExpr.Format()
            => ApiCmdSpec.format((T)this);

        CmdUri IApiCmd.Uri
            => new(CmdKind.App, GetType().Assembly.PartName().Format(), GetType().DisplayName(), CmdId.Format());
    }    
}