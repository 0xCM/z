//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IEmissionSink : IEventSink, IDisposable
    {

    }

    [Free]
    public interface IEmissionSink<S> : IEmissionSink
        where S : IEmissionSink<S>
    {

    }
}