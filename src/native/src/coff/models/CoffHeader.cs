//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Reflection.PortableExecutable;

    /// <summary>
    /// At the beginning of an object file, or immediately after the signature of an image file,
    /// is a standard COFF file header in the following format. Note that the Windows loader limits
    /// the number of sections to 96.
    /// </summary>
    /// <remarks>
    /// See https://docs.microsoft.com/en-us/dotnet/api/system.reflection.portableexecutable.coffheader?view=net-5.0
    /// </remarks>
    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
    public record struct CoffHeader : IRecord<CoffHeader>
    {
        public const string TableId = "coff.header";

        /// <summary>
        /// Specifies the target machine's CPU architecture.
        /// </summary>
        public Machine Machine;

        /// <summary>
        /// The section count that indicates the size of the section table, which immediately follows the headers.
        /// </summary>
        public ushort NumberOfSections;

        /// <summary>
        /// The low 32 bits of the number of seconds since 00:00 January 1, 1970, which indicates when the file was created.
        /// </summary>
        public Hex32 TimeDateStamp;

        /// <summary>
        /// The file pointer to the COFF symbol table, or zero if no COFF symbol table is present. This value should be zero for a PE image.
        /// </summary>
        public Address32 PointerToSymbolTable;

        /// <summary>
        /// Specifies the number of entries in the symbol table. This data can be used to locate
        /// the string table, which immediately follows the symbol table. This value should be zero for a PE image.
        /// </summary>
        public uint NumberOfSymbols;

        /// <summary>
        /// Gets the size of the optional header, which is required for executable files but not for object files. This value should be zero for an object file.
        /// </summary>
        public Hex16 SizeOfOptionalHeader;

        /// <summary>
        /// https://docs.microsoft.com/en-us/dotnet/api/system.reflection.portableexecutable.characteristics?view=net-5.0
        /// </summary>
        public Characteristics Characteristics;
    }
}