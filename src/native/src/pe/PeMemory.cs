//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using Windows;

    public unsafe class PeMemory
    {
        readonly MemorySeg Source;

        MemoryReaders.MemoryReader Reader;

        IMAGE_DOS_HEADER _DosHeader;
        
        CoffHeader _CoffHeader;

        public PeMemory(MemorySeg src)
        {
            Source = src;
            Reader = MemoryReaders.reader(Source.BaseAddress, Source.Size);
            ReadHeaders();
        }

        void ReadHeaders()
        {
            _DosHeader = Reader.Read<IMAGE_DOS_HEADER>();
            Require.equal(_DosHeader.e_magic, IMAGE_DOS_HEADER.MAGIC);
            
            var sigoffset = Reader.Seek(PeSig.LocationOffset).Read<uint>();
            var headerOffset = sigoffset + PeSig.Size;
            _CoffHeader = Reader.Seek(headerOffset).Read<CoffHeader>();
        }

        public ref readonly IMAGE_DOS_HEADER DosHeader 
            => ref _DosHeader;

        public ref readonly CoffHeader CoffHeader
            => ref _CoffHeader;

        public D Directory<D>(PeDirectoryEntry entry)
            where D : unmanaged
                => Reader.View<D>(entry.Rva);
    }
}