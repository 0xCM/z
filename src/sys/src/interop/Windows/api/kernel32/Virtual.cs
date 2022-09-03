// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Windows
{
    partial struct Kernel32
    {
        [DllImport(LibName, SetLastError = true), Free]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool VirtualFree(void* lpAddress, UIntPtr sizeToFree, [MarshalAs(UnmanagedType.U4)] MemFreeType freeType);

        [DllImport(LibName, ExactSpelling = true), Free]
        public static extern unsafe void* VirtualAlloc(void* lpAddress, UIntPtr dwSize, int flAllocationType, int flProtect);

        [DllImport(LibName, SetLastError = true, ExactSpelling = true), Free]
        public static extern unsafe UIntPtr VirtualQuery(void* lpAddress, ref MEMORY_BASIC_INFORMATION lpBuffer, UIntPtr dwLength);

        [DllImport(LibName, SetLastError = true), Free]
        public static extern int VirtualQueryEx(IntPtr hProcess, IntPtr lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, uint dwLength);

        [DllImport(LibName), Free]
        public static extern bool VirtualProtectEx(IntPtr hProc, IntPtr pCode, UIntPtr codelen, PageProtection flags, out PageProtection oldFlags);

        [DllImport(LibName, SetLastError = true), Free]
        static extern UIntPtr VirtualAlloc(UIntPtr lpAddress, UIntPtr allocSize, MemAllocType allocationType, PageProtection protection);
    }
}