//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Windows
{

    [ApiHost,Free]
    public unsafe class WinProcs : Win64<WinProcs>
    {
        [DllImport(ImageNames.Kernel32, SetLastError = true)]
        public static extern Handle OpenProcess(ProcessAccessRight dwDesiredAccess, bool bInheritHandle, ProcessId dwProcessId);

        [DllImport(ImageNames.Kernel32, SetLastError = true)]
        public static extern bool ReadProcessMemory([In] Handle hProcess, MemoryAddress lpBaseAddress, void* lpBuffer, int dwSize, out int lpNumberOfBytesRead);

    }
}