//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class HexDataReader : AppService<HexDataReader>
    {
        public HexFileStats Stats(FilePath src)
        {
            using var reader = src.LineReader(TextEncodingKind.Asci);
            var line = TextLine.Empty;
            var count = 0u;
            var size = 0u;
            var rowsize = 0u;
            while(reader.Next(out line))
            {
                if(line.IsNonEmpty)
                {
                    ref readonly var content = ref line.Content;
                    if(rowsize == 0)
                    {
                        var j = text.index(content, Chars.Space);
                        if(j > 0)
                        {
                            var data = text.remove(text.right(content,j), Chars.Space);
                            rowsize = (uint)data.Length/2;
                        }
                    }
                    count++;
                    size += rowsize;
                }
            }
            var stats = new HexFileStats();
            stats.RowCount = count;
            stats.RowSize = rowsize;
            stats.TotalSize = size;
            stats.Path = src;
            return stats;
        }

        public Index<HexFileStats> Stats(ReadOnlySpan<FilePath> src)
        {
            var count = src.Length;
            var dst = alloc<HexFileStats>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                seek(dst,i) = Stats(path);
            }
            return dst;
        }

        public uint ReadData(in HexFileStats stats, uint offset, Span<byte> dst)
        {
            var lines = stats.Path.ReadNumberedLines();
            var count = lines.Count;
            var i = offset;
            for(var j=0; j<count; j++)
            {
                ref readonly var line = ref lines[j];
                if(line.IsEmpty)
                    continue;

                ref readonly var content = ref line.Content;
                var k = text.index(content, Chars.Space);
                if(k > 0)
                {
                    var data = text.right(content,k);
                    i+= Hex.data(data, i, dst);
                }
            }
            return i - offset;
        }

        public Index<HexDataRow> Read(FilePath src)
        {
            var lines = src.ReadNumberedLines();
            var count = lines.Count;
            var buffer = alloc<HexDataRow>(count);
            var empty = HexDataRow.Empty;
            var result = Outcome.Success;
            for(var j=0; j<count; j++)
            {
                ref var dst = ref seek(buffer,j);
                ref readonly var line = ref lines[j];
                dst = empty;
                if(line.IsEmpty)
                    continue;
                else
                {
                    ref readonly var content = ref line.Content;
                    var k = text.index(content, Chars.Space);
                    if(k > 0)
                    {
                        result = DataParser.parse(text.left(content,k), out dst.Address);
                        if(result.Fail)
                            break;
                        result = DataParser.parse(text.right(content,k), out dst.Data);
                        if(result.Fail)
                        {
                            break;
                        }
                    }
                }
            }

            if(result.Fail)
            {
                Error(result.Message);
                return sys.empty<HexDataRow>();
            }

            return buffer;
        }
    }
}