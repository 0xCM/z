// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Windows
{
    // The target architecture of a given executable image.  The various values correspond to the
    // magic numbers defined by the PE Executable Image File Format.
    // http://www.microsoft.com/whdc/system/platform/firmware/PECOFF.mspx
    public enum MachineType : ushort
    {
        None = 0x0,

        X64 = 0x8664,

        X86 = 0x14c,

        IA64 = 0x200
    }
}