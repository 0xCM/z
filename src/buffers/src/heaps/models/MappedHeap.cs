//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public unsafe class MappedHeap : IDisposable
    {
        const uint DirectoryOffset = 4;

        readonly MemoryFile Source;

        readonly MemoryAddress Base;

        public MappedHeap(MemoryFile src)
        {
            Source = src;
            Base = src.BaseAddress;
        }

        ReadOnlySpan<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => sys.cover(Base.Pointer<byte>(), Source.FileSize);
        }
        
        ReadOnlySpan<byte> Storage
        {
            [MethodImpl(Inline)]
            get => slice(Bytes, DirectoryOffset + (EntryCount*size<HeapEntry>()));
        }

        public uint EntryCount
        {
            [MethodImpl(Inline)]
            get => first(uint32(Bytes));
        }

        public ReadOnlySpan<HeapEntry> Directory
        {
            [MethodImpl(Inline)]
            get => slice(recover<HeapEntry>(slice(Bytes,DirectoryOffset)),EntryCount);
        }

        [MethodImpl(Inline)]
        public ref readonly HeapEntry Entry(uint index)
            => ref skip(Directory, index);

        [MethodImpl(Inline)]
        public ReadOnlySpan<byte> Data(HeapEntry entry)
            => slice(Storage, (uint)entry.Offset, entry.Size);

        [MethodImpl(Inline)]
        public ReadOnlySpan<byte> Data(uint index)
            => Data(Entry(index));


        public void Dispose()
        {
            Source.Dispose();
        }
    }
}