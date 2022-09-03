//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITable
    {
        uint RowCount {get;}
    }

    public interface ITable<T> : ITable
        where T : struct
    {
        Span<T> Rows {get;}

        uint ITable.RowCount
            => (uint)Rows.Length;
    }

    public interface ITable<T,K> : ITable<T>
        where T : struct
        where K : unmanaged, IRowKey<K>
    {
        ReadOnlySpan<K> Keys {get;}
    }
}