// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Windows
{
    // Flags used for opening a file handle (e.g. in a call to CreateFile), that determine the requested permission level.
    //
    [Flags]
    public enum FileAccessFlags : uint
    {
        GENERIC_WRITE = 0x40000000,

        GENERIC_READ = 0x80000000
    }

    // Flags that control caching and other behavior of the underlying file object.  Used only for
    // CreateFile.
    [Flags]
    public enum FileFlagsAndAttributes : uint
    {
        NORMAL = 0x80,

        OPEN_REPARSE_POINT = 0x200000,

        SEQUENTIAL_SCAN = 0x8000000,

        RANDOM_ACCESS = 0x10000000,

        NO_BUFFERING = 0x20000000,

        OVERLAPPED = 0x40000000
    }

}