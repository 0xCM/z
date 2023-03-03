//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Reflection.Metadata;
    using System.Reflection.PortableExecutable;

    [ApiHost, Free]
    public unsafe class ClrMdMemory : IDisposable
    {
        public static ClrMdMemory create(FilePath src)
            => new ClrMdMemory(src);

        readonly MemoryFile Source;

        readonly PEReader PE;

        readonly MetadataReader MD;

        readonly ulong ImageSize;

        readonly Ptr<byte> BasePointer;

        readonly PEMemoryBlock MtadataBlock;

        public ClrMdMemory(FilePath src)
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

        [MethodImpl(Inline)]
        public PEMemoryBlock SectionData(DirectoryEntry src)
            => PE.GetSectionData(src.RelativeVirtualAddress);

        [MethodImpl(Inline)]
        public unsafe ReadOnlySpan<byte> Read(PEMemoryBlock src)
            => sys.cover<byte>(src.Pointer, (uint)src.Length);

        public ReadOnlySpan<byte> Resources
        {
            [MethodImpl(Inline)]
            get => Read(SectionData(ResourceDirectory));
        }

        public static ClrMdMemory Empty
            => new ClrMdMemory(FilePath.Empty);
    }
}