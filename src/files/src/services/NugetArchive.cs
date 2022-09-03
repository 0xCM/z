//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class NugetArchive : DbArchive<NugetArchive>
    {
        static DbArchive NUGET_PACKAGES()
            => FS.dir(ProjectSettings.Default.Setting("NUGET_PACKAGES").ValueText);

        public NugetArchive(IDbArchive home)
            : base(home)
        {
        }

        public NugetArchive()
            : base(NUGET_PACKAGES())
        {
        }
    }   
}