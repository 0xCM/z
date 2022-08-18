// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Windows
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESSOR_INFO
    {
        /// <summary>
        /// PROCESSOR_ARCHITECTURE_AMD64 9 | x64 (AMD or Intel)
        /// PROCESSOR_ARCHITECTURE_ARM 5 | ARM
        /// PROCESSOR_ARCHITECTURE_IA64 6 | Intel Itanium-based
        /// PROCESSOR_ARCHITECTURE_INTEL 0 | x86
        /// PROCESSOR_ARCHITECTURE_UNKNOWN 0xffff | Unknown architecture.
        /// </summary>
        public ushort wProcessorArchitecture;

        public ushort wReserved;
    }
}