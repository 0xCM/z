//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public delegate void WfEventLogger(IEvent e);

    [Free]

    public interface IWfEvent : IEvent
    {

    }

    /// <summary>
    /// Characterizes a reified event
    /// </summary>
    /// <typeparam name="H">The reifying type</typeparam>
    [Free]
    public interface IWfEvent<H> : IEvent, IEvent<H>
        where H : IWfEvent<H>, new()
    {

    }

    /// <summary>
    /// Characterizes a reified event with parametric content
    /// </summary>
    /// <typeparam name="H">The event type</typeparam>
    /// <typeparam name="T">The content type</typeparam>
    [Free]
    public interface IWfEvent<H,T> : IWfEvent<H>
        where H : IWfEvent<H,T>, new()
    {
        EventPayload<T> Payload => default;
    }
}