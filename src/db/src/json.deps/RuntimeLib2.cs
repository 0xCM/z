//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonDeps
    {
        public record struct RuntimeLib
        {
            public Seq<AssetGroup> AssemblyGroups;

            public Seq<AssetGroup> NativeLibraries;

            public Seq<ResourceAssembly> ResourceAssemblies;
        }
    }
}