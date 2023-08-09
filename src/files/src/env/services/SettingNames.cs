//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [LiteralProvider("env")]
    public readonly struct SettingNames
    {
        public const string LlvmRoot = nameof(LlvmRoot);

        public const string EnvRoot = nameof(EnvRoot);
        
        public const string Toolbase = nameof(Toolbase);        

        public const string DbRoot = nameof(DbRoot);

        public const string DevRoot = nameof(DevRoot);

        public const string DevOps = nameof(DevOps);

        public const string Control = nameof(Control);

        public const string ProcDumps = nameof(ProcDumps);

        public const string Capture = nameof(Capture);

        public const string Archives = nameof(Archives);

        public const string DevTools = nameof(DevTools);

        public const string SdkRoot = nameof(SdkRoot);

        public const string PkgRoot = nameof(PkgRoot);

        public const string PubRoot = nameof(PubRoot);

        public const string Dashboard = nameof(Dashboard);

        public const string XedDb = "intel.xed";

        public const string SdmDb = "intel.sdm";

        public const string SdeDb = "intel.sde";

        public const string InxDb = "intel.intrinsics";

        public const string EnvDb = nameof(EnvDb);

        public const string WinKits = nameof(WinKits);

        public const string DevPacks = nameof(DevPacks);

        public const string BuildKits = nameof(BuildKits);

        public const string IntelKits = nameof(IntelKits);
    }
}