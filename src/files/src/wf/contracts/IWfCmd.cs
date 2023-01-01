//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IWfCmd : ICmd
    {
        CmdUri Uri {get;}
    }

    [Free]
    public interface IWfCmd<T> : IWfCmd
        where T : IWfCmd<T>, new()
    {
        CmdId ICmd.CmdId
            => CmdId.identify<T>();

        string IExpr.Format()
            => Cmd.format((T)this);

        CmdUri IWfCmd.Uri
            => new(CmdKind.App, GetType().Assembly.PartName().Format(), GetType().DisplayName(), CmdId.Format());
    }    
}