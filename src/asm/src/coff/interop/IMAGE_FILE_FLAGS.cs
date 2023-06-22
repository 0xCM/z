//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Windows
{
    [SymSource("images"), Flags]
    public enum IMAGE_FILE_FLAGS : uint
    {
        IMAGE_FILE_RELOCS_STRIPPED = 0x1u,

        IMAGE_FILE_EXECUTABLE_IMAGE = 0x2u,

        IMAGE_FILE_LINE_NUMS_STRIPPED = 0x4u,

        IMAGE_FILE_LOCAL_SYMS_STRIPPED = 0x8u,

        IMAGE_FILE_AGGRESIVE_WS_TRIM = 0x10u,

        IMAGE_FILE_LARGE_ADDRESS_AWARE = 0x20u,

        IMAGE_FILE_BYTES_REVERSED_LO = 0x80u,

        IMAGE_FILE_32BIT_MACHINE = 0x100u,

        IMAGE_FILE_DEBUG_STRIPPED = 0x200u,

        IMAGE_FILE_REMOVABLE_RUN_FROM_SWAP = 0x400u,

        IMAGE_FILE_NET_RUN_FROM_SWAP = 0x800u,

        IMAGE_FILE_SYSTEM = 0x1000u,

        IMAGE_FILE_DLL = 0x2000u,

        IMAGE_FILE_UP_SYSTEM_ONLY = 0x4000u,

        IMAGE_FILE_BYTES_REVERSED_HI = 0x8000u
    }
}