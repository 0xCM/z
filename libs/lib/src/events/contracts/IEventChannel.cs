//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEventChannel
    {
        EventId Raise<E>(E e)
            where E : IWfEvent;
    }
}