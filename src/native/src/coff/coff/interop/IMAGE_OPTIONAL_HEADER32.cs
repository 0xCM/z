//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Windows
{
    [StructLayout(LayoutKind.Sequential)]
    public struct IMAGE_OPTIONAL_HEADER32
    {
        public IMAGE_OPTIONAL_HEADER_MAGIC Magic;

        public byte MajorLinkerVersion;

        public byte MinorLinkerVersion;

        public uint SizeOfCode;

        public uint SizeOfInitializedData;

        public uint SizeOfUninitializedData;

        public uint AddressOfEntryPoint;

        public uint BaseOfCode;

        public uint BaseOfData;

        public uint ImageBase;

        public uint SectionAlignment;

        public uint FileAlignment;

        public ushort MajorOperatingSystemVersion;

        public ushort MinorOperatingSystemVersion;

        public ushort MajorImageVersion;

        public ushort MinorImageVersion;

        public ushort MajorSubsystemVersion;

        public ushort MinorSubsystemVersion;

        public uint Win32VersionValue;

        public uint SizeOfImage;

        public uint SizeOfHeaders;

        public uint CheckSum;

        public IMAGE_SUBSYSTEM Subsystem;

        public IMAGE_DLL_FLAGS DllCharacteristics;

        public uint SizeOfStackReserve;

        public uint SizeOfStackCommit;

        public uint SizeOfHeapReserve;

        public uint SizeOfHeapCommit;

        [Obsolete]
        public uint LoaderFlags;

        public uint NumberOfRvaAndSizes;

        public IMAGE_DATA_DIRECTORY[] DataDirectory;
    }
}