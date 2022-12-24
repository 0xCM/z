//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public delegate void DataReceiver<T>(T data);

    [Free]
    public delegate void EventReceiver(IEvent e);

    [Free]
    public delegate void EventReceiver<E>(in E e)
        where E : struct, IEvent;
}