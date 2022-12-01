//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class NugetFile : FilePack<NugetFile>
    {
        public NugetFile(FileUri src)
            : base(src, PackageKind.Nuget)
        {

        }

        public override FileKind FileKind => FileKind.Nuget;
    }
}