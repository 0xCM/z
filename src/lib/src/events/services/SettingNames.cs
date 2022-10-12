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

        public const string DOTNET_ROOT = nameof(DOTNET_ROOT);

        public const string VCPKG_ROOT = nameof(VCPKG_ROOT);

        public const string CARGO_HOME = nameof(CARGO_HOME);

        public const string GHCUP_INSTALL_BASE_PREFIX = nameof(GHCUP_INSTALL_BASE_PREFIX);

        public const string DENO_INSTALL_ROOT = nameof(DENO_INSTALL_ROOT);

        public const string DENO_DIR = nameof(DENO_DIR);

        public const string DENO_CACHE = nameof(DENO_CACHE);

        public const string NUGET_PACKAGES = nameof(NUGET_PACKAGES);

        public const string DevPacks = nameof(DevPacks);

        public const string Archives = nameof(Archives);

        public const string DevTools = nameof(DevTools);

        public const string SdkRoot = nameof(SdkRoot);
    }
}