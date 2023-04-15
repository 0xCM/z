//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Windows
{    
    /// <summary>
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-image_debug_directory
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public record struct IMAGE_DEBUG_DIRECTORY
    {
        uint Characteristics;

        public uint TimeDateStamp;

        public ushort MajorVersion;

        public ushort MinorVersion;

        public IMAGE_DEBUG_TYPE Type;

        /// <summary>
        /// The size of the debugging information, in bytes. This value does not include the debug directory itself
        /// </summary>
        public uint SizeOfData;

        /// <summary>
        /// The address of the debugging information when the image is loaded, relative to the image base.
        /// </summary>
        public Address32 AddressOfRawData;

        /// <summary>
        /// A file pointer to the debugging information.
        /// </summary>
        public Address32 PointerToRawData;        
    }
}