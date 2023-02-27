//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Reflection.PortableExecutable;

    [StructLayout(LayoutKind.Sequential), Record(TableId)]
    public record struct PeFileInfo
    {
        public const string TableId = "pe.info";

        /// <summary>
        /// Specifies the target machine's CPU architecture.
        /// </summary>
        public Machine Machine;

        /// <summary>
        /// The preferred base address of the image when loaded
        /// </summary>
        public MemoryAddress ImageBase;

        /// <summary>
        /// The <see cref='ImageBase'/> relative entry address
        /// </summary>
        public Address32 EntryPointOffset;

        /// <summary>
        /// The <see cref='ImageBase'/> relative .text section
        /// </summary>
        public Address32 CodeOffset;

        /// <summary>
        /// The aggregate size of the .text sections
        /// </summary>
        public uint CodeSize;

        /// <summary>
        /// The <see cref='ImageBase'/> relative data address
        /// </summary>
        public Address32 DataOffset;

        /// <summary>
        /// The loaded image size
        /// </summary>
        public uint ImageSize;

        /// <summary>
        /// The location/size of the export directory
        /// </summary>
        public PeDirectoryEntry ExportDir;

        /// <summary>
        /// The location/size of the import directory
        /// </summary>
        public PeDirectoryEntry ImportDir;

        /// <summary>
        /// The location/size of the import address directory
        /// </summary>
        public PeDirectoryEntry ImportAddressDir;

        /// <summary>
        /// The location/size of the resource directory
        /// </summary>
        public PeDirectoryEntry ResourceDir;

        /// <summary>
        /// The location/size of the relocation directory
        /// </summary>
        public PeDirectoryEntry RelocationDir;

        /// <summary>
        /// The location/size of the load config directory
        /// </summary>
        public PeDirectoryEntry LoadConfigDir;

        /// <summary>
        /// The location/size of the load debug directory
        /// </summary>
        public PeDirectoryEntry DebugDir;

        /// <summary>
        /// https://docs.microsoft.com/en-us/dotnet/api/system.reflection.portableexecutable.characteristics?view=net-5.0
        /// </summary>
        public Characteristics Characteristics;
    }
}