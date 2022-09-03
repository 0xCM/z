//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IDbTable : IEntity
    {

    }

    [Free]
    public interface IDbTable<T> : IDbTable, IEntity<T>
        where T : IDbTable<T>, new()
    {
    }    
}