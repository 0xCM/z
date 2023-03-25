//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static sys;
    using static XedDisasmModels;

    partial class XedDisasm
    {
        public static DisasmSummary summary(ProjectContext context, in DisasmDataFile src)
        {
            var lines = sys.bag<DisasmLines>();
            summary(src.Source, context.Root(src.Source.Path), src.Blocks, lines).Require();
            var sorted = lines.ToArray().Sort();
            return new DisasmSummary(src, src.Origin, resequence(sorted.Select(line => line.Row)), sorted);
        }

        static Outcome summary(in FileRef src, in FileRef origin, Index<DisasmBlock> blocks, ConcurrentBag<DisasmLines> dst)
        {
            var lines = NumberedLines(blocks);
            var expr = expressions(blocks);
            var seq = 0u;
            var result = Outcome.Success;
            var count = Require.equal(expr.Length, lines.Length);

            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref lines[i];
                var record = new XedDisasmRow();
                result = DisasmParse.parse(line.Content, out record.Encoded);
                if(result.Fail)
                    return result;

                record.DocSeq = seq++;
                record.OriginId = origin.DocId;
                record.OriginName = origin.DocName;
                result = DisasmParse.parse(line.Content, out record.IP);
                if(result.Fail)
                    break;

                record.InstructionId = asm.instid(record.OriginId, record.IP, sys.bytes(record.Encoded));
                record.EncodingId = record.InstructionId.EncodingId;
                record.Asm = expr[i];
                record.Source = src.Path;
                record.Source = record.Source.LineRef(line.LineNumber);
                record.Size = record.Encoded.Size;
                dst.Add(new (blocks[i], record));
            }

            return result;
        }

        static Index<AsmExpr> expressions(ReadOnlySpan<DisasmBlock> src)
        {
            var dst = list<AsmExpr>();
            foreach(var block in src)
            {
                foreach(var line in block.Lines)
                {
                    var i = text.index(line.Content, DisasmParse.YDIS);
                    if(i >= 0)
                        dst.Add(text.trim(text.right(line.Content, i + DisasmParse.YDIS.Length)));
                }
            }
            return dst.ToArray();
        }

        static Index<TextLine> NumberedLines(ReadOnlySpan<DisasmBlock> src)
        {
            var dst = list<TextLine>();
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var lines = ref skip(src,i).Lines;
                var count = lines.Count;
                for(var j=0; j<count; j++)
                {
                    if(j == count-1)
                        dst.Add(lines[j]);
                }
            }
            return dst.ToArray();
        }
    }
}