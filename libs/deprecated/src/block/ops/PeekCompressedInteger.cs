//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
// Source      : https://github.com/dotnet/runtime/src/libraries/System.Reflection.Metadata
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class SRM
    {
        unsafe partial struct MemoryBlock
        {
            /// <summary>
            /// Decodes a compressed integer value starting at offset.
            /// See Metadata Specification section II.23.2: Blobs and signatures.
            /// </summary>
            /// <param name="offset">Offset to the start of the compressed data.</param>
            /// <param name="numberOfBytesRead">Bytes actually read.</param>
            /// <returns>
            /// Value between 0 and 0x1fffffff, or <see cref="BlobReader.InvalidCompressedInteger"/> if the value encoding is invalid.
            /// </returns>
            [MethodImpl(Inline), Op]
            public int PeekCompressedInteger(int offset, out int numberOfBytesRead)
            {
                var result = (int)unpack(this, (uint)offset, out var consumed);
                numberOfBytesRead = (int)consumed;
                return result;
            }
        }
    }
}