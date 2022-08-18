//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Collections.Immutable;

    partial class SRM
    {
        public static unsafe class BlobUtilities
        {
            static byte[] ReadBytes(byte* pSrc, int byteCount)
            {
                if (byteCount == 0)
                    return sys.empty<byte>();
                var dst = new byte[byteCount];
                Marshal.Copy((IntPtr)pSrc, dst, 0, byteCount);
                return dst;
            }

            public static ImmutableArray<byte> ReadImmutableBytes(byte* buffer, int byteCount)
            {
                byte[]? bytes = ReadBytes(buffer, byteCount);
                return ImmutableByteArrayInterop.DangerousCreateFromUnderlyingArray(ref bytes);
            }
        }
    }
}