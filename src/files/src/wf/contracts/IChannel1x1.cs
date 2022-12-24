//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IChannel1x1<T>
    {
        void Send(T x0, out T y0);
    }

    public interface IChannel1x1<F,T> : IChannel1x1<T>
        where F : unmanaged, IChannel1x1<F,T>
        where T : unmanaged
    {

    }
}