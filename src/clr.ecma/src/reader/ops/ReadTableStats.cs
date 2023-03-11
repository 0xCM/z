//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static EcmaTables;

    partial class EcmaReader
    {        
        public void ReadTableStats(ConcurrentBag<EcmaRowStats> dst)
        {
            var indicies = Symbols.values<TableIndex,byte>();
            var counts = GetRowCounts(indicies);
            var offsets = GetTableOffsets(indicies);
            var sizes = GetRowSizes(indicies);            
            var name = _AssemblyName;
            for(byte j=0; j<counts.Count; j++)
            {
                var table = (TableIndex)j;
                var rowcount = counts[table];
                var rowsize = sizes[table];
                if(rowcount != 0)
                {
                    var entry = new EcmaRowStats();
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

        public static ReadOnlySeq<EcmaRowStats> stats(IEnumerable<FilePath> src)
        {
            var dst = bag<EcmaRowStats>();

            iter(src, path => {
                using var file = Ecma.file(path);
                var reader = Ecma.reader(file);
                reader.ReadTableStats(dst);                
            }, true);
            return dst.Array().Sort();
        }
        public static void stats(ReadOnlySpan<Assembly> src, ConcurrentBag<EcmaRowStats> dst)
            => iter(src, a => stats(a,dst), true);

        public static void stats(Assembly src, ConcurrentBag<EcmaRowStats> dst)
            => EcmaReader.create(src).ReadTableStats(dst);
    }
}