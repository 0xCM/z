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
            // same as Array.BinarySearch, but without using IComparer
            [Op]
            public int BinarySearch(string[] asciiKeys, int offset)
            {
                var low = 0;
                var high = asciiKeys.Length - 1;

                while (low <= high)
                {
                    var middle = low + ((high - low) >> 1);
                    var midValue = asciiKeys[middle];

                    int comparison = CompareUtf8NullTerminatedStringWithAsciiString(offset, midValue);
                    if (comparison == 0)
                    {
                        return middle;
                    }

                    if (comparison < 0)
                    {
                        high = middle - 1;
                    }
                    else
                    {
                        low = middle + 1;
                    }
                }

                return ~low;
            }
        }
    }
}