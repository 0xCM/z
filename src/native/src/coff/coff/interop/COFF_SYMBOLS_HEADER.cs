//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Windows
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-image_coff_symbols_header
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct COFF_SYMBOLS_HEADER
    {
        public uint NumberOfSymbols;

        public uint LvaToFirstSymbol;

        public uint NumberOfLinenumbers;

        public uint LvaToFirstLinenumber;

        public uint RvaToFirstByteOfCode;

        public uint RvaToLastByteOfCode;

        public uint RvaToFirstByteOfData;

        public uint RvaToLastByteOfData;
    }
}