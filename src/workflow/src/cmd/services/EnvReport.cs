//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class EnvReport
    {
        public EnvId EnvId {get;}

        public EnvVarKind Kind {get;}

        public CfgEntries Cfg {get;}

        public EnvVars Vars {get;}        

        public EnvReport(EnvId id, EnvVarKind kind, CfgEntries cfg, EnvVars vars)
        {
            EnvId = id;
            Kind = kind;
            Cfg = cfg;
            Vars = vars;
        }
    }
}