//-----------------------------------------------------------------------------
// Copyright   :  .NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct MinidumpRecords
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MINIDUMP_HANDLE_DATA_STREAM : IRecord<MINIDUMP_HANDLE_DATA_STREAM>
        {
            public uint SizeOfHeader;

            public uint SizeOfDescriptor;

            public uint NumberOfDescriptors;

            public uint Reserved;
        }
    }
}