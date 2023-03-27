//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Windows
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/windows/win32/procthread/process-security-and-access-rights
    /// </summary>
    [Flags]
    public enum ProcessAccessRight : uint
    {
        /// <summary>
        /// All possible access rights for a process object  If PROCESS_ALL_ACCESS must be used, set _WIN32_WINNT to the minimum operating system targeted by your application
        /// </summary>
        AllAccess = 0x001F0FFF,

        /// <summary>
        /// Required to use this process as the parent process with PROC_THREAD_ATTRIBUTE_PARENT_PROCESS.
        /// </summary>
        PROCESS_CREATE_PROCESS = 0x0080,

        /// <summary>
        /// Required to create a thread.
        /// </summary>
        PROCESS_CREATE_THREAD = 0x0002,

        /// <summary>
        /// Required to duplicate a handle using DuplicateHandle.
        /// </summary>
        PROCESS_DUP_HANDLE = 0x0040,

        /// <summary>
        /// Required to retrieve certain information about a process, such as its token, exit code, and priority class (see OpenProcessToken).
        /// </summary>
        PROCESS_QUERY_INFORMATION = 0x0400,

        /// <summary>
        /// Required to retrieve certain information about a process (see GetExitCodeProcess, GetPriorityClass, IsProcessInJob, QueryFullProcessImageName). 
        /// A handle that has the PROCESS_QUERY_INFORMATION access right is automatically granted PROCESS_QUERY_LIMITED_INFORMATION.
        /// </summary>
        PROCESS_QUERY_LIMITED_INFORMATION = 0x1000,

        /// <summary>
        /// Required to set certain information about a process, such as its priority class (see SetPriorityClass).
        /// </summary>
        PROCESS_SET_INFORMATION = 0x0200,

        /// <summary>
        /// Required to set memory limits using SetProcessWorkingSetSize.
        /// </summary>
        PROCESS_SET_QUOTA  = 0x0100,

        /// <summary>
        /// Required to suspend or resume a process.
        /// </summary>
        PROCESS_SUSPEND_RESUME = 0x0800,

        /// <summary>
        /// Required to terminate a process using TerminateProcess.
        /// </summary>
        PROCESS_TERMINATE = 0x0001,

        /// <summary>
        /// Required to perform an operation on the address space of a process (see VirtualProtectEx and WriteProcessMemory).
        /// </summary>
        PROCESS_VM_OPERATION  = 0x0008,

        /// <summary>
        /// Required to read memory in a process using ReadProcessMemory".
        /// </summary>
        PROCESS_VM_READ = 0x0010,

        /// <summary>
        /// Required to write to memory in a process using WriteProcessMemory.
        /// </summary>
        PROCESS_VM_WRITE  = 0x0020,
        
        /// <summary>
        /// Required to wait for the process to terminate using the wait functions.
        /// </summary>
        SYNCHRONIZE = 0x00100000
    }
}