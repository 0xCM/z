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
        CmdRoute Route
            => Cmd.route(typeof(T));
        
        ReadOnlySeq<CmdField> Fields 
            => Cmd.fields(typeof(T));

        CmdId ICmd.CmdId
            => CmdId.identify<T>();

        string IExpr.Format()
            => Cmd.format((T)this);

        CmdUri IApiCmd.Uri
            => new(CmdKind.App, GetType().Assembly.PartName().Format(), GetType().DisplayName(), CmdId.Format());
    }    
}