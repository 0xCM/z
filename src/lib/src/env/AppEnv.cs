//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class AppEnv : AppSettings<AppEnv,FolderPath>
    {
        public static ref readonly AppEnv Cfg => ref Instance;
        
        readonly FolderPath _DbRoot;

        readonly FolderPath _DevRoot;

        public AppEnv()
        {
            _DbRoot = FS.dir(Environment.GetEnvironmentVariable(SettingNames.DbRoot));
            _DevRoot = FS.dir(Environment.GetEnvironmentVariable(SettingNames.DevRoot));
        }

        public FolderPath DbRoot() => _DbRoot;

        public FolderPath Logs() => DbRoot() + FS.folder("logs");

        public FolderPath DevRoot() => _DevRoot;

        static AppEnv Instance = new();        
    }
}