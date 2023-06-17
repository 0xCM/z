//-----------------------------------------------------------------------------
// Copyright   :  None
// License     :  Any, except GPL or variants thereof
//-----------------------------------------------------------------------------
namespace Windows
{
    [StructLayout(StructLayout,Pack =1)]
    public struct IMAGE_FILE_HEADER
    {
        public ushort Machine;

        public ushort NumberOfSections;

        public uint TimeDateStamp;

        public uint PointerToSymbolTable;

        public uint NumberOfSymbols;

        public ushort SizeOfOptionalHeader;

        public ushort Characteristics;
    }    
}