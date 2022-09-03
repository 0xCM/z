//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
// Source      : https://github.com/dotnet/runtime/src/libraries/System.Reflection.Metadata
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Reflection.Metadata;

    partial class SRM
    {
        /// <summary>
        /// Provides helpers to decode strings from unmanaged memory to System.String while avoiding
        /// intermediate allocation.
        /// </summary>
        internal static unsafe class EncodingHelper
        {
            public static string DecodeUtf8(byte* bytes, int byteCount, byte[]? prefix, MetadataStringDecoder utf8Decoder)
                => SRM.DecodeUtf8(bytes, byteCount, prefix, utf8Decoder);
        }
    }
}