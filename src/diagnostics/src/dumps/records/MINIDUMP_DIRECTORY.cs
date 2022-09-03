//-----------------------------------------------------------------------------
// Copyright   :  .NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct MinidumpRecords
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MINIDUMP_DIRECTORY : IRecord<MINIDUMP_DIRECTORY>
        {
            public MinidumpStreamType StreamType;

            public MINIDUMP_LOCATION_DESCRIPTOR Location;
        }
    }
}