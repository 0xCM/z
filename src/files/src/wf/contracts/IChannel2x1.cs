//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    public interface IChannel2x1<T>
        where T : unmanaged
    {
        void Send(T x0, T x1, out T y0);
    }

    public interface IChannel2x1<F,T> : IChannel2x1<T>
        where F : unmanaged, IChannel2x1<F,T>
        where T : unmanaged
    {

    }
}