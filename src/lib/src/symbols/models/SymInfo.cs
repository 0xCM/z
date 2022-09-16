//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [StructLayout(StructLayout), Record(TableId)]
    public struct SymInfo
    {
        public const string TableId = "tokens";

        public const byte FieldCount = 9;

        [Parser]
        public static Outcome parse(string src, out SymInfo dst)
        {
            var outcome = Outcome.Success;
            var j=0;
            var cells = text.split(src,Chars.Pipe);
            if(cells.Length != FieldCount)
            {
                dst = default;
                return (false, AppMsg.FieldCountMismatch.Format(FieldCount, cells.Length));
            }

            DataParser.parse(skip(cells,j++), out dst.Group);
            DataParser.parse(skip(cells,j++), out dst.Type);
            DataParser.parse(skip(cells,j++), out dst.Size);
            DataParser.parse(skip(cells,j++), out dst.Index);
            DataParser.parse(skip(cells,j++), out dst.Name);
            DataParser.parse(skip(cells,j++), out dst.Value);
            DataParser.parse(skip(cells,j++), out dst.Expr);
            DataParser.parse(skip(cells,j++), out dst.Description);
            return outcome;
        }

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