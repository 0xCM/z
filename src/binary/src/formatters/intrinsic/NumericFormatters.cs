//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BinaryFormatters
    {
        sealed class UInt8Formatter : UnmanagedFormatter<byte> {}
        sealed class UInt16Formatter : UnmanagedFormatter<ushort> {}
        sealed class UInt32Formatter : UnmanagedFormatter<uint> {}
        sealed class UInt64Formatter : UnmanagedFormatter<ulong> {}

        sealed class Int8Formatter : UnmanagedFormatter<sbyte> {}
        sealed class Int16Formatter : UnmanagedFormatter<short> {}
        sealed class Int32Formatter : UnmanagedFormatter<int> {}
        sealed class Int64Formatter : UnmanagedFormatter<long> {}
    }
}