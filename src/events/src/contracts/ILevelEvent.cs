//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ILevelEvent : IEvent
    {
        LogLevel EventLevel {get;}
    }

    [Free]
    public interface ILevelEvent<H> : IEvent, IWfEvent<H>
        where H : ILevelEvent<H>, new()
    {

    }

    [Free]
    public interface ILevelEvent<H,T> : ILevelEvent<H>, IWfEvent<H,T>
        where H : ILevelEvent<H,T>, new()
    {

    }
}