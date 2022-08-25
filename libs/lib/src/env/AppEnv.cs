//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class AppEnv : AppSettings<AppEnv,FolderPath>
    {
        public static AppEnv Default => new();

        public readonly FolderPath EnvRoot;

        public AppEnv()
        {
            EnvRoot = FS.dir(Environment.GetEnvironmentVariable(SettingNames.EnvRoot));
        }

        public AppEnv(FolderPath src)
        {
            EnvRoot = src;
        }

        public FolderPath DbRoot() => EnvRoot + FS.folder("db");

        public FolderPath Logs() => DbRoot() + FS.folder("logs");
    }
}