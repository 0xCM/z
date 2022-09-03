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
        public const string LlvmRoot = nameof(LlvmRoot);

        public const string EnvRoot = nameof(EnvRoot);
        
        public const string Toolbase = nameof(Toolbase);        
    }
}