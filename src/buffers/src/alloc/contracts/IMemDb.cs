//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Free]
public interface IMemDb : IAllocation
{
    MemoryFileInfo Description {get;}

    ReadOnlySpan<byte> Load(AllocToken token);

    AllocToken Store(ReadOnlySpan<byte> src);

    void Store<T>(AllocToken token, ReadOnlySpan<T> src)
        where T : unmanaged;
    
    AllocToken Reserve(ByteSize size);
    
    Span<byte> Edit(AllocToken token);

    ulong Capacity
        => Description.Size;
    
    MemoryAddress IAllocation.BaseAddress
        => Description.BaseAddress;
    
    ByteSize IAllocation.Size
        => Description.Size;
    
    void IDisposable.Dispose()
    {

    }
}
