//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
// Source      : https://github.com/dotnet/runtime/src/libraries/System.Reflection.Metadata
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Reflection.Metadata;
    using System.Diagnostics;

    using static Root;
    using static core;
    using static SRM;

    partial class XTend
    {
        const int TemplateParameterOffset_AttributeUsageTarget = 2;

        [MethodImpl(Inline), Op]
        public static uint Raw(this BlobHandle src)
            => uint32(src);

        [MethodImpl(Inline), Op]
        public static uint Raw(this StringHandle src)
            => uint32(src);

        [MethodImpl(Inline), Op]
        public static uint Raw(this UserStringHandle src)
            => uint32(src);

        [MethodImpl(Inline), Op]
        public static int GetHeapOffset(this BlobHandle src)
            => int32(src);

        [MethodImpl(Inline), Op]
        public static int GetHeapOffset(this StringHandle src)
        {
            var data = ((ulong)src.Raw()) << 3;
            return ((int)(data >> 3));
        }

        [MethodImpl(Inline), Op]
        public static int GetHeapOffset(this UserStringHandle src)
            => (int)src.Raw();

        [MethodImpl(Inline), Op]
        public static bool IsEmpty(this StringHandle src)
            => src.IsNil;

        [MethodImpl(Inline), Op]
        public static bool IsNonEmpty(this StringHandle src)
            => !src.IsEmpty();

        // bits:
        //     31: IsVirtual
        // 29..31: type (non-virtual: String, DotTerminatedString; virtual: VirtualString, WinRTPrefixedString)
        //  0..28: Heap offset or Virtual index
        public static string Format(this StringHandle src)
            => src.GetHeapOffset().FormatHex();

        [MethodImpl(Inline), Op]
        internal static BlobHeap.VirtualIndex GetVirtualIndex(this BlobHandle src)
            => (BlobHeap.VirtualIndex)(src.Raw() & 0xff);

        [MethodImpl(Inline), Op]
        internal static StringHeap.VirtualIndex GetVirtualIndex(this StringHandle src)
            => (StringHeap.VirtualIndex)(src.Raw() & HeapHandleType.OffsetMask);

        [MethodImpl(Inline), Op]
        public static bool IsVirtual(this BlobHandle src)
            => (src.Raw() & TokenTypeIds.VirtualBit) != 0;

        [MethodImpl(Inline), Op]
        public static bool IsVirtual(this StringHandle src)
            => (src.Raw() & TokenTypeIds.VirtualBit) != 0;

        [MethodImpl(Inline), Op]
        public static ushort VirtualValue(this BlobHandle src)
            => unchecked((ushort)(src.Raw() >> 8));

        [MethodImpl(Inline), Op]
        internal static unsafe void SubstituteTemplateParameters(this BlobHandle src, byte[] blob)
        {
            Debug.Assert(blob.Length >= TemplateParameterOffset_AttributeUsageTarget + 4);

            fixed (byte* ptr = &blob[TemplateParameterOffset_AttributeUsageTarget])
            {
                *((uint*)ptr) = src.VirtualValue();
            }
        }

        [MethodImpl(Inline), Op]
        public static int Index(this GuidHandle src)
            => int32(src);

        [MethodImpl(Inline), Op]
        public static StringKind StringKind(this StringHandle src)
            => (StringKind)(src.Raw() >> HeapHandleType.OffsetBitCount);
    }
}