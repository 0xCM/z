// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Windows
{
    [NativeModule(LibName)]
    public readonly partial struct Msvcrt
    {
        const string LibName = "msvcrt.dll";

        [DllImport(LibName, EntryPoint = "memcpy", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern UIntPtr memcpy(UIntPtr dest, UIntPtr src, UIntPtr count);

        [DllImport(LibName, EntryPoint = "memcpy", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern UIntPtr memcpy(IntPtr dest, UIntPtr src, UIntPtr count);
    }
}