//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static sys;

partial class XedDisasm
{
    public static XedDisasmSummary summary(in XedDisasmFile src)
    {
        var lines = sys.bag<XedDisasmLines>();
        summary(src.Source, src.Blocks, lines).Require();
        var sorted = lines.ToArray().Sort();
        return new XedDisasmSummary(src, resequence(sorted.Select(line => line.Row)), sorted);
    }

    static Outcome summary(FilePath src, Index<XedDisasmBlock> blocks, ConcurrentBag<XedDisasmLines> dst)
    {
        var lines = NumberedLines(blocks);
        var expr = expressions(blocks);
        var seq = 1u;
        var result = Outcome.Success;
        var count = Require.equal(expr.Length, lines.Length);

        for(var i=0; i<count; i++)
        {
            ref readonly var line = ref lines[i];
            var record = new XedDisasmRow();
            result = XedDisasmParse.parse(line.Content, out record.Encoded);
            if(result.Fail)
                return result;

            record.DocSeq = seq++;
            result = XedDisasmParse.parse(line.Content, out record.IP);
            if(result.Fail)
                break;


            record.Asm = expr[i];
            record.Source = src;
            record.Source = record.Source.LineRef(line.LineNumber);
            record.Size = record.Encoded.Size;
            dst.Add(new (blocks[i], record));
        }

        return result;
    }

    static Index<AsmExpr> expressions(ReadOnlySpan<XedDisasmBlock> src)
    {
        var dst = list<AsmExpr>();
        foreach(var block in src)
        {
            foreach(var line in block.Lines)
            {
                var i = text.index(line.Content, XedDisasmParse.YDIS);
                if(i >= 0)
                    dst.Add(text.trim(text.right(line.Content, i + XedDisasmParse.YDIS.Length)));
            }
        }
        return dst.ToArray();
    }

    static Index<TextLine> NumberedLines(ReadOnlySpan<XedDisasmBlock> src)
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
