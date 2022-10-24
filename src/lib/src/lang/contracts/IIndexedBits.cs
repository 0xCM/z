//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IIndexedBits : ISizedValue
    {
        bit this[uint i] {get;set;}
    }

    [Free]
    public interface IIndexedBits<T> : IIndexedBits, ISizedValue<T>
        where T : unmanaged
    {
        T IValued<T>.Value
            => sys.@as<IIndexedBits<T>,T>(this);
    }
}