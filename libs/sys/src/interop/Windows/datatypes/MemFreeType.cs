// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Windows
{
    public enum MemFreeType : uint
    {
        CoalescePlaceholders = 0x00000001,

        PreservePlaceholder = 0x00000002,

        Decommit = 0x00004000,

        Release = 0x00008000
    }
}