// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Windows
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct WORKING_SET_INFORMATION
    {
        public IntPtr EntryCount;

        // The rest of the struct is an array of PSAPI_WORKING_SET_BLOCK.  This function fetches them.
        public WORKING_SET_BLOCK Block(int idx)
        {
            fixed (WORKING_SET_INFORMATION* ptr = &this)
            {
                var blockPtr = (WORKING_SET_BLOCK*)(ptr + 1);
                return blockPtr[idx];
            }
        }
    }
}