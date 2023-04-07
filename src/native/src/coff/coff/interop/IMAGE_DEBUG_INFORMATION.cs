//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public unsafe struct IMAGE_DEBUG_INFORMATION
    {
        public LIST_ENTRY List;

        public uint ReservedSize;

        public unsafe void* ReservedMappedBase;

        public ushort ReservedMachine;

        public ushort ReservedCharacteristics;

        public uint ReservedCheckSum;

        public uint ImageBase;

        public uint SizeOfImage;

        public uint ReservedNumberOfSections;

        //public unsafe ImageSectionHeader* ReservedSections;

        public uint ReservedExportedNamesSize;

        public PSTR ReservedExportedNames;

        public uint ReservedNumberOfFunctionTableEntries;

        public unsafe IMAGE_FUNCTION_ENTRY* ReservedFunctionTableEntries;

        public uint ReservedLowestFunctionStartingAddress;

        public uint ReservedHighestFunctionEndingAddress;

        public uint ReservedNumberOfFpoTableEntries;

        public unsafe FPO_DATA* ReservedFpoTableEntries;

        public uint SizeOfCoffSymbols;

        public unsafe COFF_SYMBOLS_HEADER* CoffSymbols;

        public uint ReservedSizeOfCodeViewSymbols;

        public unsafe void* ReservedCodeViewSymbols;

        public PSTR ImageFilePath;

        public PSTR ImageFileName;

        public PSTR ReservedDebugFilePath;

        public uint ReservedTimeDateStamp;

        public BOOL ReservedRomImage;

        public unsafe IMAGE_DEBUG_DIRECTORY* ReservedDebugDirectory;

        public uint ReservedNumberOfDebugDirectories;

        public uint ReservedOriginalFunctionTableBaseAddress;

        public ulong Reserved;
    }
}