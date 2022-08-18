//-----------------------------------------------------------------------------
// Copyright   :  .NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Microsoft.Win32.SafeHandles;

    using static MinidumpRecords;

    public readonly struct DbgHelp
    {
        public const string LibName = "Dbghelp.dll";

        [DllImport(LibName, SetLastError = true), Free]
        public static extern bool MiniDumpWriteDump(IntPtr hProcess, uint ProcessId, SafeFileHandle hFile, MinidumpType DumpType, IntPtr ExceptionParam, IntPtr UserStreamParam, IntPtr CallbackParam);

        /// <summary>
        /// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/nf-minidumpapiset-minidumpreaddumpstream
        /// </summary>
        /// <param name="pDump">A pointer to the base of the mapped minidump file. The file should have been mapped into memory using the MapViewOfFile function.</param>
        /// <param name="streamNumber">The type of data to be read from the minidump file. This member can be one of the values in the MINIDUMP_STREAM_TYPE enumeration.</param>
        /// <param name="pDirectory">A pointer to a MINIDUMP_DIRECTORY structure</param>
        /// <param name="pStream">A pointer to the beginning of the minidump stream. The format of this stream depends on the value of StreamNumber. For more information, see MINIDUMP_STREAM_TYPE.</param>
        /// <param name="pStreamSize">The size of the stream pointed to by StreamPointer, in bytes</param>
        [DllImport(LibName, SetLastError = true), Free]
        public static unsafe extern bool MiniDumpReadDumpStream(IntPtr pDump, uint streamNumber, MINIDUMP_DIRECTORY* pDirectory, void* pStream, uint* pStreamSize);

        [DllImport(LibName,SetLastError = true), Free]
        public static unsafe extern bool MiniDumpReadDumpStream(IntPtr pDump, MinidumpStreamType streamType, out MINIDUMP_DIRECTORY dir, void* pStream, out uint cbStreamSize);
    }
}