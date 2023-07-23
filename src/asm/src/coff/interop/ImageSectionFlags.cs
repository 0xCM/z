//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Windows
{
    [Flags, SymSource("images")]
    public enum ImageSectionFlags : uint
    {
        /// <summary>
        /// Reserved
        /// </summary>
        RESERVED_1 = 0x1,

        /// <summary>
        /// Reserved
        /// </summary>
        RESERVED_2 = 0x2,

        /// <summary>
        /// Reserved
        /// </summary>
        RESERVED_3 = 0x4,

        TYPE_NO_PAD = 0x8u,

        /// <summary>
        /// Reserved
        /// </summary>
        Reserved_4 = 0x10u,

        /// <summary>
        /// The section contains executable code.
        /// </summary>
        CNT_CODE = 0x20u,

        /// <summary>
        /// The section contains initialized data.
        /// </summary>
        CNT_INITIALIZED_DATA = 0x40u,

        /// <summary>
        /// The section contains uninitialized data.
        /// The section contains comments or other information. This is valid only for object files.
        /// </summary>
        CNT_UNINITIALIZED_DATA = 0x80u,

        /// <summary>
        /// Reserved
        /// </summary>
        LNK_OTHER = 0x100u,

        /// <summary>
        /// The section contains comments or other information. This is valid only for object files.
        /// The section will not become part of the image. This is valid only for object files.
        /// </summary>
        LNK_INFO = 0x200u,

        /// <summary>
        /// The section will not become part of the image. This is valid only for object files.
        /// </summary>
        LNK_REMOVE = 0x800u,

        /// <summary>
        /// The section contains COMDAT data. This is valid only for object files.
        /// </summary>
        LNK_COMDAT = 0x1000u,

        /// <summary>
        /// Reserved
        /// </summary>
        RESERVED_5 = 0x2000,

        /// <summary>
        /// Reset speculative exceptions handling bits in the TLB entries for this section.
        /// </summary>
        NO_DEFER_SPEC_EXC = 0x4000u,

        /// <summary>
        /// The section contains data referenced through the global pointer.
        /// </summary>
        GPREL = 0x8000u,

        RESERVED_6 = 0x10000,

        /// <summary>
        /// 
        /// </summary>
        MEM_PURGEABLE = 0x20000,

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

        LNK_NRELOC_OVFL = 0x1000000u,

        MEM_DISCARDABLE = 0x2000000u,

        MEM_NOT_CACHED = 0x4000000u,

        MEM_NOT_PAGED = 0x8000000u,

        MEM_SHARED = 0x10000000u,

        MEM_EXECUTE = 0x20000000u,

        MEM_READ = 0x40000000u,

        MEM_WRITE = 0x80000000u,     
    }
}