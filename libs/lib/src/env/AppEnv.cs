//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class AppEnv : AppSettings<AppEnv,FS.FolderPath>
    {
        public static AppEnv Default => new();

        public readonly FS.FolderPath EnvRoot;

        public AppEnv()
        {
            EnvRoot = FS.dir(Environment.GetEnvironmentVariable(SettingNames.EnvRoot));
        }

        public AppEnv(FS.FolderPath src)
        {
            EnvRoot = src;
        }

        public FS.FolderPath DbRoot() => EnvRoot + FS.folder("db");

        public FS.FolderPath Logs() => DbRoot() + FS.folder("logs");
    }
}