//-----------------------------------------------------------------------------
// Copyright   :  .NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct MinidumpRecords
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MINIDUMP_LOCATION_DESCRIPTOR64 : IRecord<MINIDUMP_LOCATION_DESCRIPTOR64>
        {
            public ulong DataSize;

            public ulong Rva;
        }
    }
}