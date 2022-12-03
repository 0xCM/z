//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Reflection.PortableExecutable;

    using static sys;

    public struct CoffHeaderView
    {
        [MethodImpl(Inline), Op]
        public static Timestamp timestamp(Hex32 src)
            => Time.epoch(TimeSpan.FromSeconds(src));

        readonly CoffHeader Source;

        /// <summary>
        /// Specifies the target machine's CPU architecture.
        /// </summary>
        public Machine Machine
        {
            [MethodImpl(Inline)]
            get => first(recover<Machine>(bytes(Source)));
        }

        /// <summary>
        /// The section count that indicates the size of the section table, which immediately follows the headers.
        /// </summary>
        public ushort SectionCount
        {
            [MethodImpl(Inline)]
            get => Source.NumberOfSections;
        }

        /// <summary>
        /// The low 32 bits of the number of seconds since 00:00 January 1, 1970, which indicates when the file was created.
        /// </summary>
        public Timestamp Timestamp
        {
            [MethodImpl(Inline)]
            get => timestamp(Source.TimeDateStamp);
        }

        /// <summary>
        /// The file pointer to the COFF symbol table, or zero if no COFF symbol table is present. This value should be zero for a PE image.
        /// </summary>
        public Address32 SymTableOffset
        {
            [MethodImpl(Inline)]
            get => Source.PointerToSymbolTable;
        }

        /// <summary>
        /// Specifies the number of entries in the symbol table. This data can be used to locate
        /// the string table, which immediately follows the symbol table. This value should be zero for a PE image.
        /// </summary>
        public uint SymCount
        {
            [MethodImpl(Inline)]
            get => Source.NumberOfSymbols;
        }

        /// <summary>
        /// Gets the size of the optional header, which is required for executable files but not for object files. This value should be zero for an object file.
        /// </summary>
        public Hex16 OptionalHeaderSize
        {
            [MethodImpl(Inline)]
            get => Source.SizeOfOptionalHeader;
        }

        /// <summary>
        /// https://docs.microsoft.com/en-us/dotnet/api/system.reflection.portableexecutable.characteristics?view=net-5.0
        /// </summary>
        public Characteristics Flags
        {
            [MethodImpl(Inline)]
            get => Source.Characteristics;
        }

        public bool HasOptionalHeader
        {
            [MethodImpl(Inline)]
            get => OptionalHeaderSize != 0;
        }
    }
}