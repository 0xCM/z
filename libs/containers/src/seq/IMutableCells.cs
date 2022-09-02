//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public interface IMutableCells<T> : ICellSeq<T>
    {
        Span<T> Edit {get;}

        ReadOnlySpan<T> ICellSeq<T>.View
            => Edit;

        new ref T this[int index]
            => ref seek(Edit,index);

        new ref T this[uint index]
            => ref seek(Edit,index);

        new ref T First
            => ref first(Edit);

        ref readonly T ICellSeq<T>.this[int index]
            => ref skip(Edit,index);

        ref readonly T ICellSeq<T>.this[uint index]
            => ref skip(Edit,index);

        ref readonly T ICellSeq<T>.First
            => ref first(Edit);
    }
}