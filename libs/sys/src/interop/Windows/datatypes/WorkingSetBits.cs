// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Windows
{
    [Flags]
    public enum WorkingSetBits
    {
        ShareCountShift = 1,

        ShareCountMask = 0x7,

        Win32ProtectionShift = 0,

        Win32ProtectionMask = 0x7FF,

        Shared = 0x100,
    };
}