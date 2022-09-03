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
            // Always RowNumber....
            [MethodImpl(Inline), Op]
            public int LinearSearchReference(int rowSize, int referenceOffset, uint referenceValue, bool isReferenceSmall)
            {
                int currOffset = referenceOffset;
                int totalSize = Length;
                while (currOffset < totalSize)
                {
                    var currReference = PeekReferenceUnchecked(currOffset, isReferenceSmall);
                    if (currReference == referenceValue)
                        return currOffset / rowSize;

                    currOffset += rowSize;
                }

                return -1;
            }
        }
    }
}