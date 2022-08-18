//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct VcInfo
    {
        public FS.FolderPath VsRoot;

        public FS.FolderPath ToolRoot;

        public Version128 Version;

        public FS.FolderPath ToolVersionRoot;

        public static VcInfo Empty
            => default;

        public bool IsEmpty
            => ToolRoot.IsEmpty;
    }
}