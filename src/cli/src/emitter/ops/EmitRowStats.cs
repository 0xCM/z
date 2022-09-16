//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class CliEmitter
    {
        public void EmitRowStats(IApiPack dst)
        {
            var src = ApiMd.Parts;
            var buffer = bag<CliRowStats>();
            stats(src,buffer);
            EmitRowStats(ApiMd.Parts, dst.Metadata().Table<CliRowStats>());
        }

        public void EmitRowStats(ReadOnlySpan<Assembly> src, FilePath dst)
        {
            var buffer = bag<CliRowStats>();
            stats(src,buffer);
            var rows = buffer.ToSeq().Sort();
            TableEmit(rows, dst);
        }

        public static void stats(ReadOnlySpan<Assembly> src, ConcurrentBag<CliRowStats> dst)
            => iter(src, a => stats(a,dst), PllExec);

        public static void stats(Assembly src, ConcurrentBag<CliRowStats> dst)
        {
            var indicies = Symbols.values<TableIndex,byte>();
            var reader = CliReader.create(src);
            var counts = reader.GetRowCounts(indicies);
            var offsets = reader.GetTableOffsets(indicies);
            var sizes = reader.GetRowSizes(indicies);
            var name = src.GetSimpleName();
            for(byte j=0; j<counts.Count; j++)
            {
                var table = (TableIndex)j;
                var rowcount = counts[table];
                var rowsize = sizes[table];
                if(rowcount != 0)
                {
                    var entry = new CliRowStats();
                    entry.AssemblyName = name;
                    entry.TableName = table.ToString();
                    entry.TableOffset = offsets[table];
                    entry.TableIndex = j;
                    entry.RowCount = rowcount;
                    entry.RowSize = rowsize;
                    entry.TableSize = rowcount*rowsize;
                    dst.Add(entry);
                }
            }
        }
    }
}