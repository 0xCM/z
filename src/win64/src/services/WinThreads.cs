//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Windows
{
    [ApiHost,Free]
    public unsafe class WinThreads : Win64<WinThreads>
    {
        [DllImport(ImageNames.Kernel32, SetLastError = true)]
        public static extern Handle OpenThread(ThreadAccessRight dwDesiredAccess, bool bInheritHandle, ThreadId dwThreadId);

    }
}