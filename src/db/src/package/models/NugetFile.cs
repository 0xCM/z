//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class NugetPackge : Package<NugetPackge>
    {
        public NugetPackge(FileUri src)
            : base(src, PackageKind.Nuget)
        {

        }
    }
}