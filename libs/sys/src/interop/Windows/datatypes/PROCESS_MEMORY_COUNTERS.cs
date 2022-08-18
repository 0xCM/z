// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Windows
{
    [StructLayout(LayoutKind.Sequential, Size = 40)]
    public struct PROCESS_MEMORY_COUNTERS
    {
        public uint cb;

        public uint PageFaultCount;

        public uint PeakWorkingSetSize;

        public uint WorkingSetSize;

        public uint QuotaPeakPagedPoolUsage;

        public uint QuotaPagedPoolUsage;

        public uint QuotaPeakNonPagedPoolUsage;

        public uint QuotaNonPagedPoolUsage;

        public uint PagefileUsage;

        public uint PeakPagefileUsage;
    }
}
