// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Windows
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct MEMORY_BASIC_INFORMATION
    {
        public ulong BaseAddress;

        public ulong AllocationBase;

        public PageProtection AllocationProtect;

        public ushort PartitionId;

        public ulong RegionSize;

        public MemState State;

        public PageProtection Protect;

        public MemType Type;
    }
}