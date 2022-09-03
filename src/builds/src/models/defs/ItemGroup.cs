//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Build
    {
        public sealed record class ItemGroup : ProjectGroup<IProjectItem>
        {
            public ItemGroup(params ProjectItem[] src)
                : base(GroupKind.ItemGroup, src)
            {

            }

            public ItemGroup()
                : base(GroupKind.ItemGroup)
            {

            }
        }
    }
}