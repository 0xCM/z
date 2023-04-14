//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEventChannel
    {
        EventId Raise<E>(E e) 
            where E : IEvent;

        ExecFlow<Type> Creating(Type service);

        ExecToken Created(ExecFlow<Type> flow);

        ExecFlow<T> Running<T>(T msg);

        ExecFlow<string> Running([CallerName] string msg = null);

        ExecToken Ran<T>(ExecFlow<T> flow, [CallerName] string msg = null);

        ExecToken Ran(ExecFlow flow, bool success = true);
        
        ExecToken Ran<T>(ExecFlow<T> flow, string msg, FlairKind flair = FlairKind.Ran);

        ExecToken<D> Ran<D>(ExecFlow src, D data, FlairKind flair = FlairKind.Ran);

        ExecFlow<T> Executing<T>(T cmd, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : ICmd, new()
                => Running(cmd);

        ExecToken Executed<T>(ExecFlow<T> flow, [CallerName] string msg = null)
            where T : ICmd, new()
                => Ran(flow, msg);

    }
}