//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public record struct AsmTokenRecord
    {
        const string TableId = "asm.tokens";

        [Render(12)]
        public uint Seq;

        [Render(16)]
        public string Group;

        [Render(24)]
        public string Kind;

        [Render(12)]
        public uint Index;

        [Render(24)]
        public string Name;

        [Render(16)]
        public SymVal Value;

        [Render(16)]
        public SymExpr Expr;
    }
}