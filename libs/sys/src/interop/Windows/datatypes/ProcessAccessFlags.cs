// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Windows
{
    // Flags indicating the level of permission requested when opening a handle to an external
    // process.  Used by OpenProcess().
    [Flags]
    public enum ProcessAccessFlags : uint
    {
        NONE = 0x0,

        ALL = 0x001F0FFF,

        VM_OPERATION = 0x00000008,

        VM_READ = 0x00000010,

        QUERY_INFORMATION = 0x00000400,

        QUERY_LIMITED_INFORMATION = 0x00001000
    }
}