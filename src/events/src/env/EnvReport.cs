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

        public readonly ToolCatalog Tools;

        public EnvReport(EnvId id, EnvVarKind kind, EnvVars vars, ToolCatalog tools)
        {
            EnvId = id;
            Kind = kind;
            Vars = vars;
            Tools = tools;
        }
    }
}