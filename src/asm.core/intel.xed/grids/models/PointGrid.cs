//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IDataStore
    {
        uint Size {get;}

        Span<byte> Data {get;}

        ref byte First
        {
            [MethodImpl(Inline)]
            get => ref core.first(Data);
        }

        ref byte this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref core.seek(Data,i);
        }

        ref byte this[int i]
        {
            [MethodImpl(Inline)]
            get => ref core.seek(Data,i);
        }

        ref T As<T>()
            where T : unmanaged, IDataStore<T>
                => ref core.@as<T>(First);
    }

    public interface IDataStore<T> : IDataStore
        where T : unmanaged, IDataStore<T>
    {
        uint IDataStore.Size
            => core.size<T>();

        Span<byte> IDataStore.Data
            => core.bytes((T)this);
    }

    partial class XedGrids
    {
        public readonly struct Grid<T>
            where T : unmanaged, IDataStore<T>
        {
            public readonly byte Rows;

            public readonly byte Cols;

            readonly T Storage;

            [MethodImpl(Inline)]
            public Grid(byte rows, byte cols, T data)
            {
                Rows = rows;
                Cols = cols;
                Storage = data;
            }
        }
    }
}