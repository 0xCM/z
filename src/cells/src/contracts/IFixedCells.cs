//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

/// <summary>
/// Characterizes a sequence of blittable fixed-with cells of immutable length
/// </summary>
[Free]
public interface IFixedCells : ICellSeq, ISized
{        
    NativeSize CellSize {get;}
    
    ByteSize ISized.Size
        => CellSize.ByteCount * Count;
    
    BitWidth ISized.BitWidth
        => CellSize.Width * Count;
}

[Free]
public interface IFixedCells<T> : IFixedCells, ISeq<T>, IEnumerable<T>
    where T : unmanaged
{
    NativeSize IFixedCells.CellSize
        => Sized.native<T>();
    
    IEnumerator<T> IEnumerable<T>.GetEnumerator()
        => sys.@throw<IEnumerator<T>>();

    IEnumerator IEnumerable.GetEnumerator()
        => sys.@throw<IEnumerator>();
}
