//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Reflection.Metadata;
    using System.Reflection.PortableExecutable;

    [ApiHost, Free]
    public unsafe class ClrMemoryMap : IDisposable
    {
        public static ClrMemoryMap create(FS.FilePath src)
            => new ClrMemoryMap(src);

        readonly MemoryFile Source;

        public readonly PEReader PE;

        public readonly MetadataReader MD;

        public readonly ulong ImageSize;

        public readonly Ptr<byte> BasePointer;

        public readonly PEMemoryBlock MtadataBlock;

        public ClrMemoryMap(FS.FilePath src)
        {
            Require.invariant(src.IsNonEmpty);
            Source = MemoryFiles.map(src);
            BasePointer = Source.BaseAddress.Pointer<byte>();
            PE = new PEReader(BasePointer, (int)Source.FileSize);
            ImageSize = Source.FileSize;
            MD = PE.GetMetadataReader();
            MtadataBlock = PE.GetMetadata();
        }


        public void Dispose()
        {
            PE.Dispose();
            Source.Dispose();
        }

        public DirectoryEntry ResourceDirectory
        {
            [MethodImpl(Inline)]
            get => PeHeaders.PEHeader.ResourceTableDirectory;
        }

        public MemorySeg ResourceSegment
        {
            [MethodImpl(Inline)]
            get => new MemorySeg(((MemoryAddress)ResourceDirectory.RelativeVirtualAddress).Pointer<byte>(), ResourceDirectory.Size);
        }

        public PEHeaders PeHeaders
        {
            [MethodImpl(Inline)]
            get => PE.PEHeaders;
        }

        public CorHeader CorHeader
        {
            [MethodImpl(Inline)]
            get => PeHeaders.CorHeader;
        }

        [MethodImpl(Inline)]
        public PEMemoryBlock SectonData(DirectoryEntry src)
            => PE.GetSectionData(src.RelativeVirtualAddress);

        [MethodImpl(Inline)]
        public unsafe ReadOnlySpan<byte> Read(PEMemoryBlock src)
            => core.cover<byte>(src.Pointer, (uint)src.Length);

        public ReadOnlySpan<byte> Resources
        {
            [MethodImpl(Inline)]
            get => Read(SectonData(ResourceDirectory));
        }

        public static ClrMemoryMap Empty
            => new ClrMemoryMap(FS.FilePath.Empty);
    }
}