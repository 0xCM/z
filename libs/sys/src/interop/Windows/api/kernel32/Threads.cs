namespace Windows
{
    partial struct Kernel32
    {
        /// <summary>
        /// Opens an existing thread object.
        /// </summary>
        /// <param name="access">The access to the thread object. This access right is checked against the security descriptor for the thread
        /// If the caller has enabled the SeDebugPrivilege privilege, the requested access is granted regardless of the contents of the security descriptor</param>
        /// <param name="bInheritHandle">If this value is TRUE, processes created by this process will inherit the handle. Otherwise, the processes do not inherit this handle</param>
        /// <param name="dwThreadId">The identifier of the thread to be opened</param>
        /// <returns>If the function succeeds, the return value is an open handle to the specified thread.</returns>
        [DllImport(LibName, SetLastError = true), Free]
        public static extern IntPtr OpenThread(ThreadAccess access, bool bInheritHandle, uint dwThreadId);

        [DllImport(LibName, SetLastError = true), Free]
        public static unsafe extern bool GetThreadContext(IntPtr hThread, IntPtr pContext);

        [DllImport(LibName, SetLastError = true), Free]
        public static unsafe extern bool GetThreadContext(IntPtr hThread, Amd64Context* pContext);

        /// <summary>
        /// Get the OS ID of the current thread
        /// </summary>
        [DllImport(LibName), Free]
        public static extern uint GetCurrentThreadId();

        /// <summary>
        /// Gets the handle of the current thread
        /// </summary>
        [DllImport(LibName), Free]
        public static extern IntPtr GetCurrentThread();

        /// <summary>
        /// Suspends a handle-identified thread
        /// </summary>
        /// <param name="hThread">The handle of the thread to suspend</param>
        [DllImport(LibName, SetLastError = true)]
        public static extern int SuspendThread(IntPtr hThread);

        /// <summary>
        /// Resumes a handle-identified thread
        /// </summary>
        /// <param name="hThread">The handle of the thread to resume</param>
        [DllImport(LibName, SetLastError = true)]
        public static extern int ResumeThread(IntPtr hThread);
    }
}