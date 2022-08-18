//-----------------------------------------------------------------------------
// Copyright   :  .NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct MinidumpRecords
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MINIDUMP_LOCATION_DESCRIPTOR : IRecord<MINIDUMP_LOCATION_DESCRIPTOR>
        {
            public uint DataSize;

            public uint Rva;
        }
    }
}