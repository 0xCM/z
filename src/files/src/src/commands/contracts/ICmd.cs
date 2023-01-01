//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmd<T> : ICmd
        where T : ICmd<T>, new()
    {
        CmdRoute Route
            => Cmd.route(typeof(T));
        
        ReadOnlySeq<CmdField> Fields 
            => Cmd.fields(typeof(T));

        CmdId ICmd.CmdId
            => CmdId.identify<T>();

        string IExpr.Format()
            => Cmd.format((T)this);
    }
}