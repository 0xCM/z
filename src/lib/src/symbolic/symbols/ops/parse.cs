//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Symbols
    {
        [Parser]
        public static Outcome parse(string src, out SymInfo dst)
        {
            const byte FieldCount = 9;
            var outcome = Outcome.Success;
            var j=0;
            var cells = text.split(src,Chars.Pipe);
            if(cells.Length != FieldCount)
            {
                dst = default;
                return (false, AppMsg.FieldCountMismatch.Format(FieldCount, cells.Length));
            }

            dst.Group = skip(cells,j++);
            dst.Type = skip(cells,j++);
            Sizes.parse(skip(cells,j++), out dst.Size);
            uint.TryParse(skip(cells,j++), out dst.Index);
            dst.Name = skip(cells,j++);

            //DataParser.parse(skip(cells,j++), out dst.Group);
            //DataParser.parse(skip(cells,j++), out dst.Type);
            //DataParser.parse(skip(cells,j++), out dst.Name);
            SymVal.parse(skip(cells,j++), out dst.Value);
            SymExpr.parse(skip(cells,j++), out dst.Expr);
            dst.Description = skip(cells,j++);

            //DataParser.parse(skip(cells,j++), out dst.Description);
            return outcome;
        }
    }
}