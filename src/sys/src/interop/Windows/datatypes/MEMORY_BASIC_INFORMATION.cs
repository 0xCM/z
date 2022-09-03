// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Windows
{
    using Z0;

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public record struct MEMORY_BASIC_INFORMATION
    {
        public MemoryAddress BaseAddress;

        public MemoryAddress AllocationBase;

        public PageProtection AllocationProtect;

        public ushort PartitionId;

        public ByteSize RegionSize;

        public MemState State;

        public PageProtection Protect;

        public MemType Type;
    }
}