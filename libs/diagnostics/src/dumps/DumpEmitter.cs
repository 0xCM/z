//-----------------------------------------------------------------------------
// Copyright   :  .NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Microsoft.Win32.SafeHandles;

    using static DumpEmitter.MINIDUMP_TYPE;

    public class DumpEmitter
    {
        public static void emit(Process src, FilePath dst)
        {
            var e = default(MINIDUMP_EXCEPTION_INFORMATION );
            using (var stream = new FileStream(dst.Format(PathSeparator.BS), FileMode.Create, FileAccess.ReadWrite, FileShare.None))
            {
                // Retry the write dump on ERROR_PARTIAL_COPY
                for (int i = 0; i < 5; i++)
                {
                    // Dump the process!
                    if (MiniDumpWriteDump(src.Handle, (uint)src.Id, stream.SafeFileHandle, DefaultType, ref e, IntPtr.Zero, IntPtr.Zero))
                    {
                        break;
                    }
                    else
                    {
                        int err = Marshal.GetHRForLastWin32Error();
                        if (err != ERROR_PARTIAL_COPY)
                            Marshal.ThrowExceptionForHR(err);
                    }
                }
                    
            }
        }

        const int ERROR_PARTIAL_COPY = unchecked((int)0x8007012b);

        [DllImport("Dbghelp.dll", SetLastError = true)]
        static extern bool MiniDumpWriteDump(IntPtr hProcess, uint ProcessId, SafeFileHandle hFile, MINIDUMP_TYPE DumpType, ref MINIDUMP_EXCEPTION_INFORMATION ExceptionParam, IntPtr UserStreamParam, IntPtr CallbackParam);

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        struct MINIDUMP_EXCEPTION_INFORMATION
        {
            public uint ThreadId;

            public IntPtr ExceptionPointers;

            public int ClientPointers;
        }

        [Flags]
        internal enum MINIDUMP_TYPE : uint
        {
            MiniDumpNormal = 0,

            MiniDumpWithDataSegs = 1 << 0,
            
            MiniDumpWithFullMemory = 1 << 1,
            
            MiniDumpWithHandleData = 1 << 2,
            
            MiniDumpFilterMemory = 1 << 3,
            
            MiniDumpScanMemory = 1 << 4,

            MiniDumpWithUnloadedModules = 1 << 5,

            MiniDumpWithIndirectlyReferencedMemory = 1 << 6,

            MiniDumpFilterModulePaths = 1 << 7,

            MiniDumpWithProcessThreadData = 1 << 8,

            MiniDumpWithPrivateReadWriteMemory = 1 << 9,

            MiniDumpWithoutOptionalData = 1 << 10,

            MiniDumpWithFullMemoryInfo = 1 << 11,

            MiniDumpWithThreadInfo = 1 << 12,

            MiniDumpWithCodeSegs = 1 << 13,

            MiniDumpWithoutAuxiliaryState = 1 << 14,

            MiniDumpWithFullAuxiliaryState = 1 << 15,

            MiniDumpWithPrivateWriteCopyMemory = 1 << 16,

            MiniDumpIgnoreInaccessibleMemory = 1 << 17,

            MiniDumpWithTokenInformation = 1 << 18,

            MiniDumpWithModuleHeaders = 1 << 19,

            MiniDumpFilterTriage = 1 << 20,

            MiniDumpWithAvxXStateContext = 1 << 21,

            MiniDumpWithIptTrace = 1 << 22,

            MiniDumpValidTypeFlags = (-1) ^ ((~1) << 22)
        }

        const MINIDUMP_TYPE DefaultType = 
              MiniDumpWithPrivateReadWriteMemory 
            | MiniDumpWithDataSegs
            | MiniDumpWithHandleData
            | MiniDumpWithUnloadedModules
            | MiniDumpWithThreadInfo
            | MiniDumpWithTokenInformation
            | MiniDumpWithFullMemory
            | MiniDumpWithFullMemoryInfo
            | MiniDumpWithAvxXStateContext
            ;
    }

    // public readonly struct DumpEmitter
    // {
    //     const int ERROR_PARTIAL_COPY = unchecked((int)0x8007012b);

    //     public static void emit(Process process, string outputFile, DumpTypeOption type)
    //     {
    //         // Open the file for writing
    //         using (var stream = new FileStream(outputFile, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
    //         {
    //             MinidumpType dumpType = MinidumpType.MiniDumpNormal;
    //             switch (type)
    //             {
    //                 case DumpTypeOption.Everything:
    //                     dumpType = MinidumpType.MiniDumpWithFullMemory |
    //                                MinidumpType.MiniDumpWithDataSegs |
    //                                MinidumpType.MiniDumpWithHandleData |
    //                                // MinidumpType.MiniDumpWithUnloadedModules |
    //                                MinidumpType.MiniDumpWithFullMemoryInfo |
    //                                MinidumpType.MiniDumpWithThreadInfo |
    //                                 MinidumpType.MiniDumpWithModuleHeaders |
    //                                 MinidumpType.MiniDumpWithAvxXStateContext |
    //                                 MinidumpType.MiniDumpWithIptTrace |
    //                                 MinidumpType.MiniDumpWithPrivateReadWriteMemory |
    //                                 // MinidumpType.MiniDumpScanMemory |
    //                                 // MinidumpType.MiniDumpWithIndirectlyReferencedMemory |
    //                                 MinidumpType.MiniDumpWithProcessThreadData |
    //                                 // MinidumpType.MiniDumpWithFullAuxiliaryState |
    //                                 MinidumpType.MiniDumpWithPrivateWriteCopyMemory |
    //                                 MinidumpType.MiniDumpIgnoreInaccessibleMemory |
    //                                 // MinidumpType.MiniDumpFilterTriage |
    //                                 MinidumpType.MiniDumpWithTokenInformation;
    //                     break;
    //             }

    //             // Retry the write dump on ERROR_PARTIAL_COPY
    //             for (int i = 0; i < 5; i++)
    //             {
    //                 // Dump the process!
    //                 if (DbgHelp.MiniDumpWriteDump(process.Handle, (uint)process.Id, stream.SafeFileHandle, dumpType, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero))
    //                 {
    //                     break;
    //                 }
    //                 else
    //                 {
    //                     int err = Marshal.GetHRForLastWin32Error();
    //                     if (err != ERROR_PARTIAL_COPY)
    //                     {
    //                         Marshal.ThrowExceptionForHR(err);
    //                     }
    //                 }
    //             }
    //         }
    //     }
    // }
}