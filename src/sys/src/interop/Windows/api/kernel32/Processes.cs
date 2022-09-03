// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Windows
{
    partial struct Kernel32
    {
        [DllImport(LibName), Free]
        public static extern bool ProcessIdToSessionId(uint dwProcessId, out uint pSessionId);

        [DllImport(LibName), Free]
        public static extern uint GetCurrentProcessorNumber();

        [DllImport(LibName), Free]
        public static extern int GetProcessId(IntPtr nativeHandle);

        [DllImport(LibName, SetLastError = true, EntryPoint = "K32EnumProcesses"), Free]
        public static extern unsafe bool EnumProcesses(int[] lpidProcess, int cb, out int lpcbNeeded);

        [DllImport(LibName, SetLastError = true), Free]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport(LibName, SetLastError = true), Free]
        public static extern IntPtr GetProcessHeap();

        [DllImport(LibName, SetLastError = true), Free]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int dwSize, out int lpNumberOfBytesRead);
    }
}