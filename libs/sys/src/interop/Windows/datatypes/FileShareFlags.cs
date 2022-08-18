// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Windows
{
    // Flags that determine what level of sharing this application requests on the target file. Used only for CreateFile.
    [Flags]
    public enum FileShareFlags : uint
    {
        EXCLUSIVE_ACCESS = 0x0,

        SHARE_READ = 0x1,

        SHARE_WRITE = 0x2,

        SHARE_DELETE = 0x4
    }
}