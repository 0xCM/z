// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Windows
{
    public struct WORKING_SET_BLOCK
    {
        public bool Shared { get { return (((WorkingSetBits)Flags) & WorkingSetBits.Shared) != 0; } }

        public int ShareCount
        {
            get
            {
                return (((int)Flags) >> (int)WorkingSetBits.ShareCountShift) & (int)WorkingSetBits.ShareCountMask;
            }
        }

        public int Win32Protection
        {
            get
            {
                return (((int)Flags) >> (int)WorkingSetBits.Win32ProtectionShift) & (int)WorkingSetBits.Win32ProtectionMask;
            }
        }

        public ulong Address { get { return ((ulong)Flags) & ~0xFFFUL; } }

        public IntPtr Flags;
    }
}