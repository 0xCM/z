//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    public interface ICellular : ICounted, IHashed, INullity
    {
        ReadOnlySpan<byte> Cells {get;}

        Hash32 IHashed.Hash
            => hash(Cells);

        uint CellCount
            => (uint)Cells.Length;

        uint CellSize
            => 1;

        uint ICounted.Count
            => CellCount;

        bool INullity.IsEmpty
            => CellCount == 0;

        bool INullity.IsNonEmpty
            => CellCount != 0;
    }

    public interface ICellular<T> : ICellular
        where T : unmanaged
    {
        new ReadOnlySpan<T> Cells {get;}

        uint ICounted.Count
            => (uint)Cells.Length;

        Hash32 IHashed.Hash
            => hash(Cells);

        ReadOnlySpan<byte> ICellular.Cells
            => sys.recover<T,byte>(Cells);

        uint ICellular.CellCount
            => (uint)Cells.Length;

        uint ICellular.CellSize
            => size<T>();
    }
}