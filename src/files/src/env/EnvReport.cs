//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class EnvReport
    {
        public readonly EnvId EnvId;

        public readonly EnvVarKind Kind;

        public readonly CfgBlock Cfg;

        public readonly EnvVars Vars;

        public EnvReport(EnvId id, EnvVarKind kind, CfgBlock cfg, EnvVars vars)
        {
            EnvId = id;
            Kind = kind;
            Cfg = cfg;
            Vars = vars;
        }
    }
}