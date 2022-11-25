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
    }
}