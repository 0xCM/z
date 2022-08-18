//-----------------------------------------------------------------------------
// Copyright   :  .NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct MinidumpRecords
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_memory_info
        /// </summary>
        public enum MINIDUMP_REGION_STATE : uint
        {
            /// <summary>
            /// Indicates committed pages for which physical storage has been allocated, either in memory or in the paging file on disk
            /// </summary>
            MEM_COMMIT = 0x1000,

            /// <summary>
            /// Indicates free pages not accessible to the calling process and available to be allocated. For free pages, the information in the AllocationBase , AllocationProtect , Protect , and Type members is undefined.
            /// </summary>
            MEM_FREE  = 0x10000,

            /// <summary>
            /// Indicates reserved pages where a range of the process's virtual address space is reserved without any physical storage being allocated. For reserved pages, the information in the Protect member is undefined.
            /// </summary>
            MEM_RESERVE = 0x2000,
        }
    }
}