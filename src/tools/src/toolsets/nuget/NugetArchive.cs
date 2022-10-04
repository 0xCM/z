//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class NugetArchive : DbArchive<NugetArchive>
    {
        public NugetArchive(IDbArchive home)
            : base(home)
        {
        }

        public NugetArchive()
            : base(Env.NUGET_PACKAGES())
        {
        }
    }   
}