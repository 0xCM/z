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
            [Op]
            public bool IsOrderedByReferenceAscending(int rowSize, int referenceOffset, bool isReferenceSmall)
            {
                int offset = referenceOffset;
                int totalSize = this.Length;

                uint previous = 0;
                while (offset < totalSize)
                {
                    uint current = PeekReferenceUnchecked(offset, isReferenceSmall);
                    if (current < previous)
                    {
                        return false;
                    }

                    previous = current;
                    offset += rowSize;
                }

                return true;
            }
        }
    }
}