//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ProcessEnv
    {
        static DbArchive archive(string src)
            => new DbArchive(FS.dir(src));

        public static DbArchive NUGET_PACKAGES()
            => Env.var(EnvVarKind.Process, EnvNames.NUGET_PACKAGES, archive);

        public static DbArchive DOTNET_ROOT()
            => Env.var(EnvVarKind.Process, EnvNames.DOTNET_ROOT, archive);

    }
}