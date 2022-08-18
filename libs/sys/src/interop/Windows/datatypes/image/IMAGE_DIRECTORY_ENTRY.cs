//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Windows
{
    [SymSource(images), Flags]
    public enum IMAGE_DIRECTORY_ENTRY : uint
    {
        IMAGE_DIRECTORY_ENTRY_ARCHITECTURE = 7u,

        IMAGE_DIRECTORY_ENTRY_BASERELOC = 5u,

        IMAGE_DIRECTORY_ENTRY_BOUND_IMPORT = 11u,

        IMAGE_DIRECTORY_ENTRY_COM_DESCRIPTOR = 14u,

        IMAGE_DIRECTORY_ENTRY_DEBUG = 6u,

        IMAGE_DIRECTORY_ENTRY_DELAY_IMPORT = 13u,

        IMAGE_DIRECTORY_ENTRY_EXCEPTION = 3u,

        IMAGE_DIRECTORY_ENTRY_EXPORT = 0u,

        IMAGE_DIRECTORY_ENTRY_GLOBALPTR = 8u,

        IMAGE_DIRECTORY_ENTRY_IAT = 12u,

        IMAGE_DIRECTORY_ENTRY_IMPORT = 1u,

        IMAGE_DIRECTORY_ENTRY_LOAD_CONFIG = 10u,

        IMAGE_DIRECTORY_ENTRY_RESOURCE = 2u,

        IMAGE_DIRECTORY_ENTRY_SECURITY = 4u,

        IMAGE_DIRECTORY_ENTRY_TLS = 9u
    }
}