//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ToolsetSpec
    {
        public readonly @string Name;

        public readonly FolderPath Home;

        public ToolsetSpec(string name, FolderPath home)
        {
            Name = name;
            Home = home;
        }
    }
}