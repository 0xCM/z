//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Windows
{
    [SymSource(images), Flags]
    public enum IMAGE_DLL_FLAGS : uint
    {
        IMAGE_DLLCHARACTERISTICS_HIGH_ENTROPY_VA = 0x20u,

        IMAGE_DLLCHARACTERISTICS_DYNAMIC_BASE = 0x40u,

        IMAGE_DLLCHARACTERISTICS_FORCE_INTEGRITY = 0x80u,

        IMAGE_DLLCHARACTERISTICS_NX_COMPAT = 0x100u,

        IMAGE_DLLCHARACTERISTICS_NO_ISOLATION = 0x200u,

        IMAGE_DLLCHARACTERISTICS_NO_SEH = 0x400u,

        IMAGE_DLLCHARACTERISTICS_NO_BIND = 0x800u,

        IMAGE_DLLCHARACTERISTICS_APPCONTAINER = 0x1000u,

        IMAGE_DLLCHARACTERISTICS_WDM_DRIVER = 0x2000u,

        IMAGE_DLLCHARACTERISTICS_GUARD_CF = 0x4000u,

        IMAGE_DLLCHARACTERISTICS_TERMINAL_SERVER_AWARE = 0x8000u,

        IMAGE_DLLCHARACTERISTICS_EX_CET_COMPAT = 0x1u
    }
}