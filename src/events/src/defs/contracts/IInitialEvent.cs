//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Free]
public interface IInitialEvent<T> : IEvent<T>
    where T : IInitialEvent<T>, IEvent<T>, new()
{

}
