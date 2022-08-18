// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Windows
{
    using static System.Runtime.InteropServices.CallingConvention;

    using Fp = System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute;

    partial struct Kernel32
    {
        [Fp(StdCall), Free]
        public delegate int DllMainDelegate(IntPtr instance, int reason, IntPtr reserved);

        [Fp(StdCall), Free]
        public delegate IntPtr GetProcAddressDelegate(IntPtr module, string name);

        [DllImport(LibName), Free]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FreeLibrary(IntPtr hModule);

        [DllImport(LibName, CharSet = CharSet.Unicode, SetLastError = true, EntryPoint = "LoadLibraryW"), Free]
        public static extern IntPtr LoadLibrary(string lpLibFileName);

        [DllImport(LibName), Free]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);
    }
}