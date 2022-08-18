//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class Build
    {
        public record class NetCoreProject
        {
            public readonly string ProjectName;

            public readonly string AssemblyName;

            readonly List<PropertyGroup> Props;

            readonly List<ItemGroup> Items;

            public NetCoreProject(string project, string ass)
            {
                Props = new();
                Items = new();
                Items.Add(new ItemGroup());
                ProjectName = project;
                AssemblyName = ass;
            }

            public NetCoreProject With(PropertyGroup group)
            {
                Props.Add(group);
                return this;
            }

            public NetCoreProject With(ItemGroup group)
            {
                Items.Add(group);
                return this;
            }

            const string ProjectOpen = "<Project Sdk=\"Microsoft.NET.Sdk\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">";

            const string ProjectClose = "</Project>";
        }
    }
}