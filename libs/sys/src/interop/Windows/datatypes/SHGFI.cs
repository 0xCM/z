// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Windows
{
    [Flags]
    public enum SHGFI : uint
    {
        Icon = 0x000000100,

        DisplayName = 0x000000200,

        TypeName = 0x000000400,

        Attributes = 0x000000800,

        IconLocation = 0x000001000,

        ExeType = 0x000002000,

        SysIconIndex = 0x000004000,

        LinkOverlay = 0x000008000,

        Selected = 0x000010000,

        Attr_Specified = 0x000020000,

        LargeIcon = 0x000000000,

        SmallIcon = 0x000000001,

        OpenIcon = 0x000000002,

        ShellIconSize = 0x000000004,

        PIDL = 0x000000008,

        UseFileAttributes = 0x000000010,

        AddOverlays = 0x000000020,

        OverlayIndex = 0x000000040,
    }
}