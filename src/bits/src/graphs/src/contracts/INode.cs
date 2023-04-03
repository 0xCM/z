//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface INode<T>  
        where T : unmanaged, IEquatable<T>
    {
        T Index {get;}
    }

    [Free]
    public interface INode32 : INode<uint>
    {

    }

}