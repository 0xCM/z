//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Free]
public interface IEventSink<E> : ISink<E>
{

}

[Free]
public interface IEventSink : IEventSink<IEvent>, IDisposable
{
    Type Host => GetType();
}
