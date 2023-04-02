//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiComplete]
    public ref struct CoffObjectView
    {
        [MethodImpl(Inline)]
        public static CoffObjectView cover(ReadOnlySpan<byte> src, uint offset = 0)
            => new CoffObjectView(src,offset);

        readonly ReadOnlySpan<byte> Data;

        readonly uint HeaderOffset;

        [MethodImpl(Inline)]
        public CoffObjectView(ReadOnlySpan<byte> data, uint offset)
        {
            Data = data;
            HeaderOffset = offset;
        }

        public ref readonly CoffHeader Header
        {
            [MethodImpl(Inline)]
            get => ref CoffObjects.header(Data, HeaderOffset);
        }

        public ByteSize HeaderSize
        {
            [MethodImpl(Inline)]
            get => size<CoffHeader>();
        }

        uint SectionHeaderOffset
        {
            [MethodImpl(Inline)]
            get => HeaderSize + (uint)Header.SizeOfOptionalHeader;
        }

        uint SectionHeaderCount
        {
            [MethodImpl(Inline)]
            get => Header.NumberOfSections;
        }

        public ReadOnlySpan<CoffSectionHeader> SectionHeaders
        {
            [MethodImpl(Inline)]
            get => recover<CoffSectionHeader>(slice(Data, SectionHeaderOffset, SectionHeaderCount*size<CoffSectionHeader>()));
        }

        public Timestamp Timestamp
        {
            [MethodImpl(Inline)]
            get => CoffObjects.timestamp(Header.TimeDateStamp);
        }

        public ref readonly uint SymbolCount
        {
            [MethodImpl(Inline)]
            get => ref Header.NumberOfSymbols;
        }

        public ref readonly uint SymbolTableOffset
        {
            [MethodImpl(Inline)]
            get => ref @as<Address32,uint>(Header.PointerToSymbolTable);
        }

        public ByteSize SymbolTableSize
        {
            [MethodImpl(Inline)]
            get => SymbolCount*size<CoffSymbol>();
        }

        public ReadOnlySpan<CoffSymbol> Symbols
        {
            [MethodImpl(Inline)]
            get => CoffStrings.symbols(Data, SymbolTableOffset, SymbolCount);
        }

        /// <summary>
        /// Immediately following the COFF symbol table is the COFF string table. The position of this table is found
        /// by taking the symbol table address in the COFF header and adding the number of symbols multiplied by the size of a symbol
        /// </summary>
        /// <remarks>
        /// https://docs.microsoft.com/en-us/windows/win32/debug/pe-format#coff-symbol-table
        /// </remarks>
        public CoffStringTable StringTable
        {
            [MethodImpl(Inline)]
            get => new CoffStringTable(slice(Data, SymbolTableOffset + SymbolTableSize));
        }
    }
}