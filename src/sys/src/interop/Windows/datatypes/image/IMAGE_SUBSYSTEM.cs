//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Windows
{
    public enum IMAGE_SUBSYSTEM : uint
    {
        IMAGE_SUBSYSTEM_UNKNOWN = 0u,

        IMAGE_SUBSYSTEM_NATIVE = 1u,

        IMAGE_SUBSYSTEM_WINDOWS_GUI = 2u,

        IMAGE_SUBSYSTEM_WINDOWS_CUI = 3u,

        IMAGE_SUBSYSTEM_OS2_CUI = 5u,

        IMAGE_SUBSYSTEM_POSIX_CUI = 7u,

        IMAGE_SUBSYSTEM_NATIVE_WINDOWS = 8u,

        IMAGE_SUBSYSTEM_WINDOWS_CE_GUI = 9u,

        IMAGE_SUBSYSTEM_EFI_APPLICATION = 10u,

        IMAGE_SUBSYSTEM_EFI_BOOT_SERVICE_DRIVER = 11u,

        IMAGE_SUBSYSTEM_EFI_RUNTIME_DRIVER = 12u,

        IMAGE_SUBSYSTEM_EFI_ROM = 13u,

        IMAGE_SUBSYSTEM_XBOX = 14u,

        IMAGE_SUBSYSTEM_WINDOWS_BOOT_APPLICATION = 0x10u,

        IMAGE_SUBSYSTEM_XBOX_CODE_CATALOG = 17u
    }
}