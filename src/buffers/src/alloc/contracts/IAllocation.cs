//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Free]
public interface IAllocation : IDisposable
{
    MemoryAddress BaseAddress {get;}

    ByteSize Size {get;}
}

[Free]
public interface IAllocation<T> : IAllocation
    where T : unmanaged
{
    Span<T> Cells {get;}

    new ByteSize Size
        => sys.size<T>();

    ByteSize IAllocation.Size
        => sys.size<T>();

    uint CellCount
        => Size/sys.size<T>();
}
