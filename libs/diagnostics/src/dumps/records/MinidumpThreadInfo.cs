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
        public struct MinidumpThreadInfo : IRecord<MinidumpThreadInfo>
        {
            public uint ThreadId;

            public uint DumpFlags;

            public uint DumpError;

            public uint ExitStatus;

            public ulong CreateTime;

            public ulong ExitTime;

            public ulong KernelTime;

            public ulong UserTime;

            public ulong StartAddress;

            public ulong Affinity;
        }
    }
}