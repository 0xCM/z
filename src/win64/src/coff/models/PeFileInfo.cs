//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Reflection.PortableExecutable;

    [StructLayout(LayoutKind.Sequential), Record(TableId)]
    public record struct PeFileInfo : IComparable<PeFileInfo>, ISequential<PeFileInfo>
    {
        public const string TableId = "pe.info";

        [Render(8)]
        public uint Seq;

        [Render(64)]
        public FileName File;

        /// <summary>
        /// Specifies the target machine's CPU architecture.
        /// </summary>
        [Render(16)]
        public Machine Machine;

        /// <summary>
        /// The preferred base address of the image when loaded
        /// </summary>
        [Render(16)]
        public MemoryAddress ImageBase;

        /// <summary>
        /// The <see cref='ImageBase'/> relative entry address
        /// </summary>
        [Render(16)]
        public Address32 EntryPointOffset;

        /// <summary>
        /// The <see cref='ImageBase'/> relative .text section
        /// </summary>
        [Render(16)]
        public Address32 CodeOffset;

        /// <summary>
        /// The aggregate size of the .text sections
        /// </summary>
        [Render(16)]
        public uint CodeSize;

        /// <summary>
        /// The <see cref='ImageBase'/> relative data address
        /// </summary>
        [Render(16)]
        public Address32 DataOffset;

        /// <summary>
        /// The loaded image size
        /// </summary>
        [Render(16)]
        public ByteSize ImageSize;

        /// <summary>
        /// https://docs.microsoft.com/en-us/dotnet/api/system.reflection.portableexecutable.characteristics?view=net-5.0
        /// </summary>
        [Render(1)]
        public Characteristics Characteristics;

        uint ISequential.Seq { get => Seq; set => Seq = value; }

        public int CompareTo(PeFileInfo src)
            => File.CompareTo(src.File);
   }
}