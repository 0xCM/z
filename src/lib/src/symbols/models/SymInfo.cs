//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(StructLayout), Record(TableId)]
    public struct SymInfo
    {
        const string TableId = "tokens";

        public const byte FieldCount = 9;

        [Render(24)]
        public @string Group;

        [Render(24)]
        public @string Type;

        [Render(12)]
        public DataSize Size;

        [Render(8)]
        public uint Index;

        [Render(64)]
        public Identifier Name;

        [Render(24)]
        public SymVal Value;

        [Render(64)]
        public SymExpr Expr;

        [Render(1)]
        public TextBlock Description;
    }
}