//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ToolsetSpec
    {
        public readonly NameOld Name;

        public readonly FS.FolderPath Home;

        public ToolsetSpec(string name, FS.FolderPath home)
        {
            Name = name;
            Home = home;
        }
    }
}