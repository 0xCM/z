//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public sealed record class EnvReport
{
    public readonly EnvId EnvName;

    public readonly EnvVars Vars;

    public readonly ToolCatalog Tools;

    public readonly ReadOnlySeq<EnvVarRow> Rows;

    public EnvReport(EnvId name, EnvVars vars, ToolCatalog tools, ReadOnlySeq<EnvVarRow> rows)
    {
        EnvName = name;
        Vars = vars;
        Tools = tools;
        Rows = rows;
    }
}
