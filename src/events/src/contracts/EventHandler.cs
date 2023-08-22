//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Free]
public delegate void DataHandler<T>(T data);

[Free]
public delegate void EventHandler(IEvent e);

[Free]
public delegate void EventHandler<E>(E e)
    where E : IEvent;
