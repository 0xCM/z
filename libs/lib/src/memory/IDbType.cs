//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IDbType : IEntity
    {
        Name Name {get;}

        DataSize Size {get;}
    }

    [Free]
    public interface IDbType<T> : IDbType, IEntity<T>, IComparable<T>, IEquatable<T>
        where T : IDbType<T>, new()
    {

    }   
}