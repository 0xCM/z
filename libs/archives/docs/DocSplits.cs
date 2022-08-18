//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static DocSplitSpec;

    public readonly struct DocSplits
    {
        public static LineRange split(FS.FilePath src, TextEncodingKind encoding, in DocSplitSpec spec, IReceiver<LineRange> dst)
        {
            using var reader = src.Reader(encoding);
            var counter = 1u;
            var count = spec.LastLine - spec.FirstLine + 1;
            var range = new LineRange(spec.FirstLine, spec.LastLine, alloc<TextLine>(count));
            var lines = range.Edit;
            var i=0;
            var line = reader.ReadLine();
            while(line != null && counter++ <= spec.LastLine && i<count)
            {
                line = reader.ReadLine();
                if(counter >= spec.FirstLine)
                    seek(lines, i++) = new TextLine(counter, line);
            }

            dst.Deposit(range);
            return range;
        }

        public static Outcome load(FS.FilePath src, out RecordSet<DocSplitSpec> dst)
        {
            dst = RecordSet<DocSplitSpec>.Empty;

            var outcome = TextGrids.load(src, out var doc);
            if(outcome.Fail)
                return outcome;

            var header = doc.Header;
            if(doc.Header.CellCount != FieldCount)
                outcome = (false, nameof(FieldCount));

            if(outcome.Fail)
                return outcome;

            var rows = doc.Rows;
            var count = rows.Length;
            dst = alloc<DocSplitSpec>(count);
            var records = dst.Edit;
            for(var i=0; i<count; i++)
            {
                outcome = load(skip(rows,i), out seek(records,i));
                if(outcome.Fail)
                    break;
            }
            return outcome;
        }

        public static Outcome load(TextRow src, out DocSplitSpec dst)
        {
            var outcome = Outcome.Success;
            dst = default;
            var count = src.CellCount;
            if(count != FieldCount)
                outcome = (false, nameof(FieldCount));
            if(!outcome)
                return outcome;

            var cells = src.Cells;
            var i=0;
            outcome += DataParser.parse(skip(cells,i++), out dst.DocId);
            outcome += DataParser.parse(skip(cells,i++), out dst.Unit);
            outcome += DataParser.parse(skip(cells,i++), out dst.FirstLine);
            outcome += DataParser.parse(skip(cells,i++), out dst.LastLine);
            return outcome;
        }
    }
}