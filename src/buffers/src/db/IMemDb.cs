//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IMemDb : IBufferAllocation
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
        
        MemoryAddress IBufferAllocation.BaseAddress
            => Description.BaseAddress;
        
        ByteSize IBufferAllocation.Size
            => Description.Size;
        
        void IDisposable.Dispose()
        {

        }
    }
}