//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
// Source      : https://github.com/dotnet/runtime/src/libraries/System.Reflection.Metadata
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class SRM
    {
        public static class StringHandleType
        {
            // The 3 high bits above the offset that specify the full string type (including virtual bit)
            public const uint TypeMask = ~(HeapHandleType.OffsetMask);

            // The string type bits excluding the virtual bit.
            public const uint NonVirtualTypeMask = TypeMask & ~(HeapHandleType.VirtualBit);

            // NUL-terminated UTF8 string on a #String heap.
            public const uint String = (0 << HeapHandleType.OffsetBitCount);

            // String on #String heap whose terminator is NUL and '.', whichever comes first.
            public const uint DotTerminatedString = (1 << HeapHandleType.OffsetBitCount);

            // Reserved values that can be used for future strings:
            public const uint ReservedString1 = (2 << HeapHandleType.OffsetBitCount);

            public const uint ReservedString2 = (3 << HeapHandleType.OffsetBitCount);

            // Virtual string identified by a virtual index
            public const uint VirtualString = HeapHandleType.VirtualBit | (0 << HeapHandleType.OffsetBitCount);

            // Virtual string whose value is a "<WinRT>" prefixed string found at the specified heap offset.
            public const uint WinRTPrefixedString = HeapHandleType.VirtualBit | (1 << HeapHandleType.OffsetBitCount);

            // Reserved virtual strings that can be used in future:
            public const uint ReservedVirtualString1 = HeapHandleType.VirtualBit | (2 << HeapHandleType.OffsetBitCount);

            public const uint ReservedVirtualString2 = HeapHandleType.VirtualBit | (3 << HeapHandleType.OffsetBitCount);
        }
    }
}