//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Settings;
    using static EnvNames;

    public sealed record class AppEnv : AppEnv<AppEnv,FolderPath>
    {
        public static ref readonly AppEnv Cfg => ref Instance;
        
        readonly AppSettings _Settings;

        public AppEnv()
        {
            _Settings = AppSettings.Default;
        }

        public DbArchive DbRoot() 
            => folder(_Settings.Setting(SettingNames.DbRoot));

        public DbArchive Logs() 
            => DbRoot().Scoped(logs);

        public DbArchive EnvRoot() 
            => folder(_Settings.Setting(SettingNames.EnvRoot));

        public DbArchive Sdks()
            => EnvRoot().Scoped(sdks);

        public DbArchive Dev()
            => folder(_Settings.Setting(SettingNames.DevRoot));

        public DbArchive Projects()
            => Dev().Scoped(projects);

        static AppEnv Instance = new();        
    }
}