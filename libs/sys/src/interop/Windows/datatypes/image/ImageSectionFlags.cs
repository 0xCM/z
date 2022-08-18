namespace Windows
{
    [Flags, SymSource(images)]
    public enum ImageSectionFlags : uint
    {
        TYPE_NO_PAD = 0x8u,

        CNT_CODE = 0x20u,

        CNT_INITIALIZED_DATA = 0x40u,

        CNT_UNINITIALIZED_DATA = 0x80u,

        LNK_OTHER = 0x100u,

        LNK_INFO = 0x200u,

        LNK_REMOVE = 0x800u,

        LNK_COMDAT = 0x1000u,

        NO_DEFER_SPEC_EXC = 0x4000u,

        GPREL = 0x8000u,

        MEM_FARDATA = 0x8000u,

        MEM_PURGEABLE = 0x20000u,

        MEM_16BIT = 0x20000u,

        MEM_LOCKED = 0x40000u,

        MEM_PRELOAD = 0x80000u,

        ALIGN_1BYTES = 0x100000u,

        ALIGN_2BYTES = 0x200000u,

        ALIGN_4BYTES = 0x300000u,

        ALIGN_8BYTES = 0x400000u,

        ALIGN_16BYTES = 0x500000u,

        ALIGN_32BYTES = 0x600000u,

        ALIGN_64BYTES = 0x700000u,

        ALIGN_128BYTES = 0x800000u,

        ALIGN_256BYTES = 0x900000u,

        ALIGN_512BYTES = 0xA00000u,

        ALIGN_1024BYTES = 0xB00000u,

        ALIGN_2048BYTES = 0xC00000u,

        ALIGN_4096BYTES = 0xD00000u,

        ALIGN_8192BYTES = 0xE00000u,

        ALIGN_MASK = 0xF00000u,

        LNK_NRELOC_OVFL = 0x1000000u,

        MEM_DISCARDABLE = 0x2000000u,

        MEM_NOT_CACHED = 0x4000000u,

        MEM_NOT_PAGED = 0x8000000u,

        MEM_SHARED = 0x10000000u,

        MEM_EXECUTE = 0x20000000u,

        MEM_READ = 0x40000000u,

        MEM_WRITE = 0x80000000u,

        SCALE_INDEX = 0x1u
    }
}