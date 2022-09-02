//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface INode
    {
        uint Index {get;}
    }

    /// <summary>
    /// Characterizes an atomic value
    /// </summary>
    /// <typeparam name="T">The value type</typeparam>
    [Free]
    public interface INode<T> : INode
    {
        T Payload {get;}
    }

    [Free]
    public interface INode<K,T> : INode<T>
        where K : unmanaged
    {
        new K Index {get;}

        uint INode.Index
            => sys.bw32(Index);
    }
}