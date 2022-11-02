//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class NugetArchive : DbArchive<NugetArchive>
    {
        static DbArchive archive(string src)
            => new DbArchive(FS.dir(src));

        static DbArchive NUGET_PACKAGES()
            => Env.var(EnvVarKind.Process, EnvTokens.NUGET_PACKAGES, archive);

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