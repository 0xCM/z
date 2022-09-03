//-----------------------------------------------------------------------------
// Copyright   :  .NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    partial struct MinidumpRecords
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MinidumpThreadInfoList : IRecord<MinidumpThreadInfoList>
        {
            public uint SizeOfHeader;

            public uint SizeOfEntry;

            public uint NumberOfEntries;
        }
    }
}