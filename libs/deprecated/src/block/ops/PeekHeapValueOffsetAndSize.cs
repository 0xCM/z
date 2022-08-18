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
            [MethodImpl(Inline), Op]
            public bool PeekHeapValueOffsetAndSize(int index, out int offset, out int size)
            {
                int bytesRead;
                int numberOfBytes = PeekCompressedInteger(index, out bytesRead);
                if (numberOfBytes == InvalidCompressedInteger)
                {
                    offset = 0;
                    size = 0;
                    return false;
                }

                offset = index + bytesRead;
                size = numberOfBytes;
                return true;
            }
        }
    }
}