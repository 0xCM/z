// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Windows
{
    // Win32 PEB structure.  Represents the process environment block of a process.
    [StructLayout(LayoutKind.Explicit, Size = 472)]
    public struct PEB
    {
        [FieldOffset(2), MarshalAs(UnmanagedType.U1)]
        public bool IsBeingDebugged;

        [FieldOffset(12)]
        public IntPtr Ldr;

        [FieldOffset(16)]
        public IntPtr ProcessParameters;

        [FieldOffset(468)]
        public uint SessionId;
    };
}
