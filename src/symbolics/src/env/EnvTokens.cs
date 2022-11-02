//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [LiteralProvider("env")]
    public class EnvTokens
    {
        public const string INCLUDE = nameof(INCLUDE);

        public const string PATH = nameof(PATH);

        public const string LIB = nameof(LIB);

        public const string DOTNET_ROOT = nameof(DOTNET_ROOT);

        public const string VCPKG_ROOT = nameof(VCPKG_ROOT);

        public const string CARGO_HOME = nameof(CARGO_HOME);

        public const string GHCUP_INSTALL_BASE_PREFIX = nameof(GHCUP_INSTALL_BASE_PREFIX);

        public const string DENO_INSTALL_ROOT = nameof(DENO_INSTALL_ROOT);

        public const string DENO_DIR = nameof(DENO_DIR);

        public const string DENO_CACHE = nameof(DENO_CACHE);

        public const string NUGET_PACKAGES = nameof(NUGET_PACKAGES);
    }
}