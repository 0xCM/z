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

        ExecToken Ran(ExecFlow flow);
        
        ExecToken Ran<T>(ExecFlow<T> flow, string msg, FlairKind flair = FlairKind.Ran);

        ExecToken<D> Ran<D>(ExecFlow src, D data, FlairKind flair = FlairKind.Ran);
    }
}