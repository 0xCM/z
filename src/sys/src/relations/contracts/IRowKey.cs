//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IRowKey
    {
        dynamic Value {get;}
    }

    public interface IRowKey<K> : IRowKey
        where K : unmanaged
    {
        new K Value {get;}

        dynamic IRowKey.Value
            => Value;
    }

    public interface IRowKey<H,K> : IRowKey<K>, IDataType<H>
        where K : unmanaged
        where H : unmanaged, IRowKey<H,K>
    {

    }
}