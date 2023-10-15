//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedRules;

partial class XedMachines
{
    public readonly record struct RuleDecl
    {
        public readonly RuleIdentity Rule;

        public readonly CellTable Table;

        public RuleDecl(CellTable table)
        {
            Table = table;
            Rule = table.Identity;
        }
    }

    public readonly record struct SeqDecl
    {
        public readonly SeqDef Def;

        public SeqDecl(SeqDef def)
        {
            Def = def;
        }

    }
}
