//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class NugetFile : Package<NugetFile>
    {
        public NugetFile(FilePath src)
            : base(src, PackageKind.Nuget)
        {

        }
    }
}