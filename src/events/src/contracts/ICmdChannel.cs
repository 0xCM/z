//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdChannel : IEventChannel
    {
        ExecFlow<T> Executing<T>(T cmd, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : IApiCmd<T>, new()
                => Running(cmd);

        ExecToken Executed<T>(ExecFlow<T> flow, [CallerName] string msg = null)
            where T : IApiCmd<T>, new()
                => Ran(flow, msg);
    }
}