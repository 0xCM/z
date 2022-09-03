//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
// Source      : https://github.com/dotnet/runtime/src/libraries/System.Reflection.Metadata
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class SRM
    {
        public static class HeapHandleType
        {
            // Heap offset values are limited to 29 bits (max compressed integer)
            public const int OffsetBitCount = 29;

            public const uint OffsetMask = (1 << OffsetBitCount) - 1;

            public const uint VirtualBit = 0x80000000;

            public static bool IsValidHeapOffset(uint offset)
            {
                return (offset & ~OffsetMask) == 0;
            }
        }
    }
}