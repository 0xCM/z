//-----------------------------------------------------------------------------
// Copyright   :  .NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;
    using Windows;

    partial struct MinidumpRecords
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_memory_info
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MINIDUMP_MEMORY_INFO : IRecord<MINIDUMP_MEMORY_INFO>
        {
            public ulong BaseAddress;

            public ulong AllocationBase;

            public uint AllocationProtect;

            public uint __alignment1;

            public ulong RegionSize;

            public MINIDUMP_REGION_STATE State;

            public PageProtection Protect;

            public MINIDUMP_REGION_TYPE Type;

            public uint __alignment2;
        }
    }
}