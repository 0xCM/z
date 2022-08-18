//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface ITable
    {
        uint RowCount {get;}
    }

    public interface ITable<T> : ITable
        where T : struct, IRecord<T>
    {
        Span<T> Rows {get;}

        uint ITable.RowCount
            => (uint)Rows.Length;
    }

    public interface ITable<T,K> : ITable<T>
        where T : struct, IRecord<T>
        where K : unmanaged, IRowKey<K>
    {
        ReadOnlySpan<K> Keys {get;}
    }
}