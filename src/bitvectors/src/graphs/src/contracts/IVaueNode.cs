//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes an atomic value
    /// </summary>
    /// <typeparam name="T">The value type</typeparam>
    [Free]
    public interface IValueNode<T>
    {
        T Value {get;}
    }

    [Free]
    public interface IValueNode<K,T> : IValueNode<T>
        where K : unmanaged
    {
        K Index {get;}
    }
}