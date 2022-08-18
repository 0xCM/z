// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Windows
{
    [Flags]
    public enum MemAllocType : uint
    {
        Commit = 0x1000,

        Reserve = 0x2000,

        Decommit = 0x4000,

        Release = 0x8000,

        Free = 0x10000,

        Private = 0x20000,

        Mapped = 0x40000,

        Reset = 0x80000,

        TopDown = 0x100000,

        WriteMatch = 0x200000,

        Physical = 0x400000,

        Rotate = 0x800000,

        PagesLarge = 0x20000000,

        Pages4Mb = 0x80000000,
    }
}