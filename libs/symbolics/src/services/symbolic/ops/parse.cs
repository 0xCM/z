//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;
    using static Arrays;

    partial class Symbolic
    {
        [Parser]
        public static Outcome parse(string src, out SymLiteralRow dst)
        {
            var outcome = Outcome.Success;
            var j=0;
            var cells = text.split(src,Chars.Pipe);
            if(cells.Length != SymLiteralRow.FieldCount)
            {
                dst = default;
                return (false, AppMsg.FieldCountMismatch.Format(SymLiteralRow.FieldCount, cells.Length));
            }

            DataParser.parse(skip(cells,j++), out dst.Component);
            DataParser.parse(skip(cells,j++), out dst.Type);
            DataParser.parse(skip(cells,j++), out dst.Group);
            DataParser.parse(skip(cells,j++), out dst.Size);
            DataParser.parse(skip(cells,j++), out dst.Index);
            DataParser.parse(skip(cells,j++), out dst.Name);
            DataParser.parse(skip(cells,j++), out dst.Symbol);
            DataParser.eparse(skip(cells,j++), out dst.DataType);
            DataParser.parse(skip(cells,j++), out dst.Value);
            DataParser.eparse(skip(cells,j++), out dst.Base);
            DataParser.parse(skip(cells,j++), out dst.Hidden);
            DataParser.parse(skip(cells,j++), out dst.Description);
            DataParser.parse(skip(cells,j++), out dst.Identity);
            return outcome;
        }
    }
}