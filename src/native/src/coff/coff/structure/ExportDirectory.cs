//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/windows/win32/debug/pe-format#export-directory-table
    /// </summary>
    [StructLayout(StructLayout), Record(TableId)]
    public record struct ExportDirectory : IImageDirectory<ExportDirectory>
    {
        const string TableId = "pe.directories.exports";

        /// <summary>
        /// Reserved
        /// </summary>
        uint ExportFlags;

        /// <summary>
        /// The time and date that the export data was created.
        /// </summary>
        public Hex32 Timestamp;

        /// <summary>
        /// The major version number. The major and minor version numbers can be set by the user.
        /// </summary>
        public ushort MajorVersion;

        /// <summary>
        /// The minor version number.
        /// </summary>
        public ushort MinorVersion;

        /// <summary>
        /// The address of the ASCII string that contains the name of the DLL. This address is relative to the image base.
        /// </summary>
        public Address32 NameRva;

        /// <summary>
        /// The starting ordinal number for exports in this image. This field specifies the starting ordinal number for the export address table. It is usually set to 1.
        /// </summary>
        public Address32 OrdinalBase;

        /// <summary>
        /// The number of entries in the export address table.
        /// </summary>
        public uint EntryCount;
        
        /// <summary>
        /// The number of entries in the name pointer table. This is also the number of entries in the ordinal table.
        /// </summary>
        public uint NamePointerCount;
        
        /// <summary>
        /// The address of the export address table, relative to the image base.
        /// </summary>
        public Address32 EntryRva;

        /// <summary>
        /// The address of the export name pointer table, relative to the image base. The table size is given by the Number of Name Pointers field.
        /// </summary>
        public Address32 NamePointerRva;
        
        /// <summary>
        /// The address of the ordinal table, relative to the image base.
        /// </summary>
        public int AddressOfNameOrdinals;

        public PeDirectoryKind DirectoryKind 
            => PeDirectoryKind.ExportTable;
        
        public string Format()
            => ToString();
    }
}