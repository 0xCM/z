//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IEventHub
    {
        ref readonly E Broadcast<E>(in E e)
            where E : struct, IEvent;
    }
}