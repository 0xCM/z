//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ICmd<T> : ICmd
        where T : ICmd<T>, new()
    {
        CmdId ICmd.CmdId
            => CmdId.identify<T>();

        string IExpr.Format()
            => CmdFormat.format((T)this);
    }    


}