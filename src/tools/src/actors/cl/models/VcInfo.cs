//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct VcInfo
    {
        public FolderPath VsRoot;

        public FolderPath ToolRoot;

        public Version128 Version;

        public FolderPath ToolVersionRoot;

        public static VcInfo Empty
            => default;

        public bool IsEmpty
            => ToolRoot.IsEmpty;
    }
}