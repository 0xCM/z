//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    partial class LlvmTableLoader
    {
        public Outcome LoadValueTypes(FS.FilePath path, out Span<ValueTypeRow> buffer)
        {
            const byte FieldCount = ValueTypeRow.FieldCount;
            var result = TextGrids.load(path, out var doc);
            buffer = default;
            if(result.Fail)
                return result;

            var rows = doc.Rows;
            var count = rows.Length;
            buffer = span<ValueTypeRow>(count);
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref var dst = ref seek(buffer,i);
                ref readonly var src = ref skip(rows,i);
                if(src.CellCount != FieldCount)
                {
                    result = (false, AppMsg.FieldCountMismatch.Format(FieldCount,src.CellCount));
                    break;
                }

                var cells = src.Cells;
                var cell = EmptyString;

                var j=0;
                cell = skip(cells, j++);
                CharBlocks.init(cell, out dst.Namespace);

                cell = skip(cells, j++);
                if(!DataParser.parse(cell, out dst.Size))
                {
                    result = (false, string.Format("Failed to parse field '{0}' from input '{1}'", nameof(dst.Size), cell));
                    break;
                }

                cell = skip(cells, j++);
                if(!DataParser.parse(cell, out dst.Value))
                {
                    result = (false, string.Format("Failed to parse field '{0}' from input '{1}'", nameof(dst.Value), cell));
                    break;
                }

                counter++;
            }

            buffer = slice(buffer, 0, counter);
            return result;
        }
    }
}