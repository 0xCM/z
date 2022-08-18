// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Windows
{
    partial struct Kernel32
    {
        public static bool CreateSymLink(string name, string target, SymLinkKind kind)
            => CreateSymbolicLinkW(name,target, kind);

        public static IntPtr CreateFile(string fileName, FileMode mode)
            => CreateFile(fileName, mode, (mode == FileMode.Append ? FileAccess.Write : FileAccess.ReadWrite));

        public static IntPtr CreateFile(string fileName, FileMode mode, FileAccess access)
            => CreateFile(fileName, mode, access, FileShare.Read);

        public static IntPtr CreateFile(string fileName, FileMode mode, FileAccess access, FileShare share)
            => CreateFile(fileName, access, share, securityAttributes: IntPtr.Zero, mode, FileAttributes.Normal, templateFile: IntPtr.Zero);

        public static bool ReadFile(IntPtr hFile, IntPtr buffer, uint numberOfBytesToRead, out uint numberOfBytesRead)
            => ReadFile(hFile, buffer, numberOfBytesToRead, out numberOfBytesRead, lpOverlapped: IntPtr.Zero);

        public static bool ReadFile(IntPtr hFile, UIntPtr buffer, uint numberOfBytesToRead, out uint numberOfBytesRead)
            => ReadFile(hFile, buffer, numberOfBytesToRead, out numberOfBytesRead, lpOverlapped: IntPtr.Zero);

        public static bool SetFilePointerEx(IntPtr file, long distanceToMove, SeekOrigin seekOrigin)
            => SetFilePointerEx(file, distanceToMove, lpNewFilePointer: IntPtr.Zero, seekOrigin);

        [DllImport(LibName, SetLastError = true), Free]
        static extern bool ReadFile(IntPtr hFile, UIntPtr lpBuffer, uint nNumberOfBytesToRead, out uint lpNumberOfBytesRead, IntPtr lpOverlapped);

        [DllImport(LibName, SetLastError = true, CharSet = CharSet.Unicode), Free]
        static extern bool CreateSymbolicLinkW(string linkName, string targtPath, SymLinkKind linkKind);

        [DllImport(LibName, SetLastError = true), Free]
        static extern bool ReadFile(IntPtr hFile, IntPtr lpBuffer, uint nNumberOfBytesToRead, out uint lpNumberOfBytesRead, IntPtr lpOverlapped);

        [DllImport(LibName, CharSet = CharSet.Unicode, SetLastError = true), Free]
        static extern IntPtr CreateFile([MarshalAs(UnmanagedType.LPTStr)] string filename, [MarshalAs(UnmanagedType.U4)] FileAccess access,
                [MarshalAs(UnmanagedType.U4)] FileShare share, IntPtr securityAttributes, [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
                [MarshalAs(UnmanagedType.U4)] FileAttributes flagsAndAttributes, IntPtr templateFile);

        [DllImport(LibName), Free]
        static extern bool SetFilePointerEx(IntPtr hFile, long liDistanceToMove, IntPtr lpNewFilePointer, [MarshalAs(UnmanagedType.U4)] SeekOrigin dwMoveMethod);
    }
}