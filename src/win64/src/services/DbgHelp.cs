//-----------------------------------------------------------------------------
// Copyright   :  .NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;
    using System.Linq;

    using static MinidumpRecords;

    public sealed partial class DbgHelp : Win64<DbgHelp>
    {
        static WinSdk WinSdk => WinSdk.create();

        public static Image load()        
        {
            var match = FS.file("dbghelp", FileKind.Dll);
            var path = WinSdk.DebuggerFiles(FileKind.Dll).Where(path => path.FileName == match).First();
            var image = ImageHandle.own(Kernel32.LoadLibrary(path.Format()));
            return new (path, image);
        }

        [DllImport(ImageNames.DbgHelp, SetLastError = true)]
        public static extern bool MiniDumpWriteDump(Ptr hProcess, uint ProcessId, Handle hFile, MinidumpType DumpType, Ptr ExceptionParam, Ptr UserStreamParam, Ptr CallbackParam);

        /// <summary>
        /// https://learn.microsoft.com/en-us/windows/win32/api/minidumpapiset/nf-minidumpapiset-minidumpreaddumpstream
        /// </summary>
        /// <param name="pDump">A pointer to the base of the mapped minidump file. The file should have been mapped into memory using the MapViewOfFile function.</param>
        /// <param name="streamNumber">The type of data to be read from the minidump file. This member can be one of the values in the MINIDUMP_STREAM_TYPE enumeration.</param>
        /// <param name="pDirectory">A pointer to a MINIDUMP_DIRECTORY structure</param>
        /// <param name="pStream">A pointer to the beginning of the minidump stream. The format of this stream depends on the value of StreamNumber. For more information, see MINIDUMP_STREAM_TYPE.</param>
        /// <param name="pStreamSize">The size of the stream pointed to by StreamPointer, in bytes</param>
        [DllImport(ImageNames.DbgHelp, SetLastError = true)]
        public static unsafe extern bool MiniDumpReadDumpStream(Ptr pDump, uint streamNumber, MINIDUMP_DIRECTORY* pDirectory, void* pStream, uint* pStreamSize);

        [DllImport(ImageNames.DbgHelp, SetLastError = true)]
        public static unsafe extern bool MiniDumpReadDumpStream(Ptr pDump, MinidumpStreamType streamType, out MINIDUMP_DIRECTORY dir, void* pStream, out uint cbStreamSize);
    }
}