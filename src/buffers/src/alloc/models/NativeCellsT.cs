//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public unsafe readonly struct NativeCells<T> : IAllocation<T>
    where T : unmanaged
{
    readonly long Id;

    public readonly MemoryAddress BaseAddress;

    public readonly uint CellCount;

    public readonly uint CellSize;

    public readonly BitWidth Width;

    [MethodImpl(Inline)]
    public NativeCells(long id, MemoryAddress @base, uint cellsize, uint count)
    {
        Id = id;
        BaseAddress = @base;
        CellCount = count;
        CellSize = cellsize;
        Width = (count*cellsize)*8;
    }

    public ByteSize Size
    {
        [MethodImpl(Inline)]
        get => (ByteSize)Width;
    }


    MemoryAddress IAllocation.BaseAddress
        => BaseAddress;

    public ref T this[uint i]
    {
        [MethodImpl(Inline)]
        get => ref Cell(i);
    }

    public ref T this[int i]
    {
        [MethodImpl(Inline)]
        get => ref Cell(i);
    }

    public Span<T> Cells
    {
        [MethodImpl(Inline)]
        get => cover(BaseAddress.Pointer<T>(), CellCount);
    }

    [MethodImpl(Inline)]
    public ref T Cell(uint index)
        => ref sys.@as<T>((BaseAddress + CellSize*index).Pointer());

    [MethodImpl(Inline)]
    public ref T Cell(int index)
        => ref Cell((uint)index);

    public void Dispose()
        => NativeCells.free(Id);
}
