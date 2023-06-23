//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XedDisasm
    {
        public Index<XedDisasmRow> LoadSummary(string name)
        {
            const byte FieldCount = XedDisasmRow.FieldCount;
            var src = EtlContext.table<XedDisasmRow>(name);
            var lines = slice(src.ReadNumberedLines().View,1);
            var count = lines.Length;
            var buffer = alloc<XedDisasmRow>(count);
            var result = Outcome.Success;
            for(var i=0; i<count; i++)
            {
                var cells = text.trim(skip(lines,i).Content.Split(Chars.Pipe));
                if(cells.Length != FieldCount)
                {
                    result = (false, Tables.FieldCountMismatch.Format(cells.Length, FieldCount));
                    break;
                }

                ref var dst = ref seek(buffer,i);

                var j = 0;
                result = DataParser.parse(skip(cells, j++), out dst.Seq);
                result = DataParser.parse(skip(cells, j++), out dst.DocSeq);
                result = HexParser.parse(skip(cells, j++), out dst.OriginId);
                result = DataParser.parse(skip(cells, j++), out dst.OriginName);
                result = EncodingId.parse(skip(cells, j++), out dst.EncodingId);
                result = AsmParsers.parse(skip(cells, j++), out dst.InstructionId);
                result = DataParser.parse(skip(cells, j++), out dst.IP);
                result = AsmBytes.parse(skip(cells, j++), out dst.Encoded);
                result = DataParser.parse(skip(cells, j++), out dst.Size);
                result = AsmExpr.parse(skip(cells, j++), out dst.Asm);
                result = DataParser.parse(skip(cells, j++), out dst.Source);
            }
            return buffer;
        }
    }
}