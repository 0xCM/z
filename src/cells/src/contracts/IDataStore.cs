//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public interface IDataStore
    {
        Span<byte> Data {get;}

        ByteSize Size 
            => Data.Length;

        ByteSize CellSize 
            => sizeof(byte);

        Count CellCount
            => (uint)((ulong)Size/(ulong)CellSize);

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
    }

    public interface IDataStore<T> : IDataStore
        where T : unmanaged
    {
        ByteSize IDataStore.CellSize
            => size<T>();

        [MethodImpl(Inline)]
        ref T Cell(uint offset)
                => ref seek(@as<T>(First), offset);

        [MethodImpl(Inline)]
        ref T Cell(int offset)
                => ref seek(@as<T>(First), offset);
        
        new ref T this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Cell(i);
        }

        new ref T this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Cell(i);
        }
    }
}