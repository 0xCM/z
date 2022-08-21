//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public interface ICellBlock<T> : IStorageBlock
        where T : unmanaged
    {
        BlockKind IStorageBlock.Kind
            => BlockKind.Generic;

        Span<T> Cells {get;}

        ByteSize ISized.ByteCount
            => Cells.Length*size<T>();

        Span<byte> IStorageBlock.Bytes
            => bytes(Cells);

        ref T this[int i]
        {
            [MethodImpl(Inline)]
            get => ref seek(Cells,i);
        }

        ref T this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref seek(Cells,i);
        }
    }

    public interface ICellBlock<F,T> : ICellBlock<T>
        where T : unmanaged
        where F : ICellBlock<F,T>
    {

    }
}