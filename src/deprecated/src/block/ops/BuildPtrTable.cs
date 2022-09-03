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
            public int[] BuildPtrTable(int numberOfRows, int rowSize, int referenceOffset, bool isReferenceSmall)
            {
                int[] ptrTable = new int[numberOfRows];
                uint[] unsortedReferences = new uint[numberOfRows];

                for (int i = 0; i < ptrTable.Length; i++)
                {
                    ptrTable[i] = i + 1;
                }

                ReadColumn(unsortedReferences, rowSize, referenceOffset, isReferenceSmall);
                Array.Sort(ptrTable, (int a, int b) => { return unsortedReferences[a - 1].CompareTo(unsortedReferences[b - 1]); });
                return ptrTable;
            }

        }
    }
}