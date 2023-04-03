//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public unsafe record class MemoryIndex
    {
        public readonly IndexHeader Header;

        public readonly MemoryAddress BaseAddress;
                        
        public readonly ReadOnlySeq<Entry> Entries;

        public Cell128 Character()
            => sys.@as<MemoryIndex,Cell128>(this);

        public record struct IndexHeader
        {
            public readonly ByteSize Size;

            public readonly ulong EntryCount;

            [MethodImpl(Inline)]
            public IndexHeader(ByteSize size, ulong count)
            {
                Size = size;
                EntryCount = count;
            }
        }

        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct Entry
        {
            public readonly Address32 Rva;

            public readonly uint Size;

            public Entry(Address32 rva, uint size)
            {
                Rva = rva;
                Size = size;                
            }

            uint NameLength
            {
                [MethodImpl(Inline)]
                get => Size - (size<uint>() + size<Address32>() + 1);
            }

            [MethodImpl(Inline)]
            public asci Name(MemoryAddress @base)
                => cover((@base + Rva).Pointer<AsciSymbol>(), NameLength);
        }

        public MemoryIndex(MemoryAddress @base, ReadOnlySeq<Entry> entries)
        {
            BaseAddress = @base;
            Entries = entries;
            var size = 0ul;
            size += size<IndexHeader>();
            size += size<MemoryAddress>();            
            for(var i=0; i<entries.Count; i++)
                size += (entries[i].Size + 1);
            Header = new IndexHeader(size, entries.Count);
        }
        
        public static void serialize(MemoryIndex src, BinaryWriter dst)
        {
            dst.WriteUnmanaged(src.Header);
            dst.WriteUnmanaged(src.BaseAddress);
            for(var i=0; i<src.Entries.Count; i++)
            {
                ref readonly var entry = ref src.Entries[i];
                dst.WriteUnmanaged(entry.Size);
                dst.WriteUnmanaged(entry.Rva);
                dst.Write(entry.Name(src.BaseAddress).Bytes);
                dst.WriteUnmanaged<byte>(0);
            }
        }

        public static void materialize(BinaryReader src, Alloc alloc)
        {
            var header = src.ReadUnmanaged<IndexHeader>();
            var size = header.Size;
            var count = header.EntryCount;

            var entries = alloc<Entry>(header.EntryCount);
            var @base = src.ReadUnmanaged<MemoryAddress>();
            for(var i=0; i<(uint)header.EntryCount; i++)
            {
                seek(entries,i) = src.ReadUnmanaged<Entry>();
                

            }
        }        
    }
}