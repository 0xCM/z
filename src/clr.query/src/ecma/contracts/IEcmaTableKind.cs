//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    public interface IEcmaTableKind<K> : IEcmaRowKey
        where K : unmanaged, IEcmaTableKind<K>
    {

    }

    public interface IEcmaTableKind<K,T> : IEcmaTableKind<K>
        where K : unmanaged, IEcmaTableKind<K>
        where T : unmanaged, IEcmaRecord<T>
    {
        Type IEcmaRowKey.RowType
            => typeof(T);
    }
}