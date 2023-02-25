//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public unsafe class MappedHeap: IDisposable
    {
        const uint DirectoryOffset = 4;

        readonly MemoryFile Source;

        readonly MemoryAddress Base;

        public MappedHeap(MemoryFile src)
        {
            Source = src;
            Base = src.BaseAddress;
        }

        ReadOnlySpan<byte> Storage
        {
            [MethodImpl(Inline)]
            get => sys.cover(Base.Pointer<byte>(), Source.FileSize);
        }
        
        ReadOnlySpan<byte> HeapData
        {
            [MethodImpl(Inline)]
            get => slice(Storage, DirectoryOffset + (EntryCount*size<HeapEntry>()));
        }

        public uint EntryCount
        {
            [MethodImpl(Inline)]
            get => first(uint32(Storage));
        }

        public ReadOnlySpan<HeapEntry> Directory
        {
            [MethodImpl(Inline)]
            get => slice(recover<HeapEntry>(slice(Storage,DirectoryOffset)),EntryCount);
        }

        [MethodImpl(Inline)]
        public ref readonly HeapEntry Entry(uint index)
            => ref skip(Directory,index);

        [MethodImpl(Inline)]
        public ReadOnlySpan<byte> EntryData(HeapEntry entry)
            => slice(HeapData, entry.Offset, entry.Length);

        [MethodImpl(Inline)]
        public ReadOnlySpan<byte> EntryData(uint index)
            => EntryData(Entry(index));


        public void Dispose()
        {
            Source.Dispose();
        }
    }
}