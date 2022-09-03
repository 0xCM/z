//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
// Source      : https://github.com/dotnet/runtime/src/libraries/System.Reflection.Metadata
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Buffers;

    partial class SRM
    {
        public static unsafe string DecodeUtf8(byte* bytes, int byteCount, byte[]? prefix, MetadataStringDecoder utf8Decoder)
        {
            if (prefix != null)
                return DecodeUtf8Prefixed(bytes, byteCount, prefix, utf8Decoder);

            if (byteCount == 0)
                return string.Empty;

            return utf8Decoder.GetString(bytes, byteCount);
        }

        unsafe static string DecodeUtf8Prefixed(byte* bytes, int byteCount, byte[] prefix, MetadataStringDecoder utf8Decoder)
        {
            int prefixedByteCount = byteCount + prefix.Length;

            if (prefixedByteCount == 0)
                return string.Empty;

            byte[] buffer = ArrayPool<byte>.Shared.Rent(prefixedByteCount);

            prefix.CopyTo(buffer, 0);
            Marshal.Copy((IntPtr)bytes, buffer, prefix.Length, byteCount);

            string result;
            fixed(byte* prefixedBytes = &buffer[0])
            {
                result = utf8Decoder.GetString(prefixedBytes, prefixedByteCount);
            }

            ArrayPool<byte>.Shared.Return(buffer);
            return result;
        }
    }
}