//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICliRowKey
    {
        CliTableKind TableKind {get;}

        Type RowType {get;}

    }

    public interface ICliTableKind<K> : ICliRowKey
        where K : unmanaged, ICliTableKind<K>
    {

    }

    public interface ICliTableKind<K,T> : ICliTableKind<K>
        where K : unmanaged, ICliTableKind<K>
        where T : unmanaged, ICliRecord<T>
    {
        Type ICliRowKey.RowType
            => typeof(T);
    }
}