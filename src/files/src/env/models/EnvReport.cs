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

        public readonly EnvVars Vars;

        public EnvReport(EnvId id, EnvVarKind kind, EnvVars vars)
        {
            EnvId = id;
            Kind = kind;
            Vars = vars;
        }
    }
}