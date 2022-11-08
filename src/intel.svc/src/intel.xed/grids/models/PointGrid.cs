//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public interface IDataStore
    {
        uint Size {get;}

        Span<byte> Data {get;}

        ref byte First
        {
            [MethodImpl(Inline)]
            get => ref first(Data);
        }

        ref byte this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref seek(Data,i);
        }

        ref byte this[int i]
        {
            [MethodImpl(Inline)]
            get => ref seek(Data,i);
        }

        ref T As<T>()
            where T : unmanaged, IDataStore<T>
                => ref @as<T>(First);
    }

    public interface IDataStore<T> : IDataStore
        where T : unmanaged, IDataStore<T>
    {
        uint IDataStore.Size
            => size<T>();

        Span<byte> IDataStore.Data
            => bytes((T)this);
    }
}