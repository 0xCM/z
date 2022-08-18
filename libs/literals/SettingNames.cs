//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiAtomic;

    [LiteralProvider(env)]
    public readonly struct SettingNames
    {
        public const string LlvmVer = nameof(LlvmVer);

        public const string WinSdkVer = nameof(WinSdkVer);

        public const string DbRoot = nameof(DbRoot);

        public const string DbSources = nameof(DbSources);

        public const string DbTargets = nameof(DbTargets);

        public const string DbProjects = nameof(DbProjects);

        public const string DbCapture = nameof(DbCapture);

        public const string Archives = nameof(Archives);

        public const string SlnRoot = nameof(SlnRoot);

        public const string Control = nameof(Control);

        public const string EnvConfig = nameof(EnvConfig);

        public const string CgRoot = nameof(CgRoot);

        public const string LlvmRoot = nameof(LlvmRoot);

        public const string DevRoot = nameof(DevRoot);

        public const string Toolbase = nameof(Toolbase);

        public const string Repos = nameof(Repos);

        public const string Tools = nameof(Tools);

        public const string Logs = nameof(Logs);

        public const string LlvmDist = nameof(LlvmDist);       

        public const string Views = nameof(Views);

        public const string NUGET_PACKAGES = nameof(NUGET_PACKAGES);
    }
}