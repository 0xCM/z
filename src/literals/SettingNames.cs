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

        public const string DbRoot = nameof(DbRoot);

        public const string DevRoot = nameof(DevRoot);

        public const string DevOps = nameof(DevOps);

        public const string Control = nameof(Control);

        public const string ProcDumps = nameof(ProcDumps);
    }
}