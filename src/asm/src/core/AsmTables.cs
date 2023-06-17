//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Linq;

    using static sys;

    public class AsmTables : WfSvc<AsmTables>
    {
        public static MsgPattern<Count> ParsingDocs => "Parsing {0} documents";

        public static MsgPattern<FileUri,string> FileParseError => "Error parsing {0}:{1}";

        public AsmTables()
        {
        }

        static Outcome<uint> rows(TextGrid doc, Span<HostAsmRecord> dst)
        {
            const byte FieldCount = HostAsmRecord.FieldCount;

            var counter = 0u;
            if(doc.Header.Labels.Length != FieldCount)
                return (false, AppMsgs.FieldCountMismatch.Format(FieldCount, doc.Header.Labels.Length));

            var count = (uint)min(doc.RowCount, dst.Length);
            var rows = doc.RowData.View;
            for(var i=0; i<count; i++)
            {
                var result = HostAsmRecord.parse(skip(rows, i), out seek(dst, i));
                if(result.Fail)
                    return result;
            }
            return count;
        }

        static Outcome<uint> rows(FilePath src, ConcurrentBag<HostAsmRecord> dst)
        {
            const byte FieldCount = HostAsmRecord.FieldCount;
            var result = TextGrids.load(src, out var doc);

            var counter = 0u;
            if(doc.Header.Labels.Length != FieldCount)
                return (false, AppMsg.CsvHeaderMismatch.Format(src, FieldCount, doc.Header.Labels.Length));

            var count = doc.RowCount;
            var rows = doc.RowData.View;
            for(var i=0; i<count; i++)
            {
                result = HostAsmRecord.parse(skip(rows,i), out HostAsmRecord statement);
                if(result)
                {
                    dst.Add(statement);
                    counter++;
                }
                else
                    return result;
            }
            return counter;
        }

        static Index<Outcome<uint>> rows(Files src, ConcurrentBag<HostAsmRecord> dst)
        {
            var results = sys.bag<Outcome<uint>>();
            iter(src, path => {
                results.Add(rows(path, dst));
            }, true);
            return results.ToArray();
        }

        public Outcome LoadHostRecords(FilePath src, out HostAsmRecord[] dst)
        {
            var result = TextGrids.load(src, out var doc);
            dst = sys.empty<HostAsmRecord>();
            if(result.Fail)
                return result;

            dst = alloc<HostAsmRecord>(doc.RowCount);
            return rows(doc,dst);
        }

        public ReadOnlySpan<AsmDataBlock> DistillBlocks(ReadOnlySpan<HostAsmRecord> records)
        {
            var count = records.Length;
            var buffer = alloc<AsmDataBlock>(count);
            ref var dst = ref first(buffer);
            var block = MemoryAddress.Zero;
            var skipping = false;
            var key = 0u;
            for(var i=0u; i<count; i++)
            {
                ref readonly var record = ref skip(records,i);
                ref readonly var BlockAddress = ref record.BlockAddress;
                ref readonly var Expression = ref record.Expression;
                var newblock = (block != BlockAddress);
                if(!newblock && skipping)
                    continue;

                if(newblock)
                {
                    block = BlockAddress;
                    skipping = false;
                }

                if(Expression.IsInvalid)
                {
                    skipping = true;
                    continue;
                }

                ref var target = ref seek(dst, key++);
                target.Key = key;
                target.BlockAddress = BlockAddress;
                target.IP = record.IP;
                target.BlockOffset = record.BlockOffset;
                target.Expression = Expression.Format();
                target.Encoded = record.Encoded.Format();
                target.Bitstring = record.Bitstring;
                target.Sig = record.Sig.Format();
                target.OpCode = record.OpCode.Format();
            }

            return slice(@readonly(buffer), 0, key);
        }

        public void EmitBlocks(ReadOnlySpan<AsmDataBlock> src, FilePath dst)
        {
            TableEmit(src, dst);
        }

        public Index<HostAsmRecord> LoadHostAsmRows(Files src, bool pll = true, bool sort = true)
        {
            const string TableId = HostAsmRecord.TableId;
            var counter = 0u;
            var dst = sys.bag<HostAsmRecord>();
            var flow = Channel.Running(string.Format("Parsing {0} records from {1} documents", TableId, src.Count));
            if(pll)
            {
                Channel.Status(ParsingDocs.Format(src.Length));
                var results = rows(src, dst);
                foreach(var result in results)
                    result.OnSuccess(count => counter += count).OnFailure(msg => Channel.Error(msg));
            }
            else
            {
                foreach(var file in src)
                {
                    var parsed = rows(file, dst);
                    if(parsed.Fail)
                        Channel.Error(FileParseError.Format(file, parsed.Message));
                    else
                        counter += parsed.Data;
                }
            }

            Ran(flow, string.Format("Parsed {0} {1} records", counter, TableId));

            var records = dst.ToArray();
            if(sort)
                Array.Sort(records);
            return records;
        }

        public Index<HostAsmRecord> LoadHostAsmRows(FolderPath src, bool pll = true, bool sort = true)
            => LoadHostAsmRows(src.Files(FS.Csv, true), pll, sort);

        public Index<AsmDetailRow> LoadAsmDetails(Files src)
        {
            var records = Lists.list<AsmDetailRow>(Pow2.T18);
            var paths = src;
            var flow = Channel.Running(string.Format("Loading {0} asm recordsets", paths.Length));
            var count = paths.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref paths[i];
                var result = LoadDetails(path, records);
                if(result)
                    counter += result.Data;
            }

            Ran(flow, string.Format("Loaded {0} total asm instruction rows", counter));
            return records.Emit();
        }

        public Index<AsmDetailRow> LoadDetails(Files src, AsmMnemonic monic)
        {
            var file = src.FirstOrDefault(f => f.FileName.Contains(monic.Format()));
            if(file.IsEmpty)
                return array<AsmDetailRow>();

            var records = Lists.list<AsmDetailRow>(Pow2.T12);
            var count = LoadDetails(file, records);
            return records.Emit();
        }

        Outcome<Count> LoadDetails(FilePath path, DataList<AsmDetailRow> dst)
        {
            var rowtype = path.FileName.WithoutExtension.Format().RightOfLast(Chars.Dot);
            var flow = Channel.Running(string.Format("Loading {0} rows from {1}", rowtype, path.ToUri()));
            var result = TextGrids.load(path, out var doc);
            var kRows = 0;
            if(result)
            {
                var kCells = doc.Header.Labels.Count;
                if(kCells != AsmDetailRow.FieldCount)
                    return (false,string.Format("Found {0} fields in {1} while {2} were expected", kCells, path.ToUri(), AsmDetailRow.FieldCount));

                var rows = doc.Rows;
                kRows = rows.Length;
                for(var j=0; j<kRows; j++)
                {
                    ref readonly var src = ref skip(rows,j);
                    if(src.CellCount != AsmDetailRow.FieldCount)
                        return (false, string.Format("Found {0} fields in {1} while {2} were expected", kCells, src, AsmDetailRow.FieldCount));
                    var loaded = AsmDetailRow.parse(src, out var detail);
                    if(!loaded)
                    {
                        Error(loaded.Message);
                        return false;
                    }

                    dst.Add(detail);
                }

                Ran(flow, string.Format("Loaded {0} {1} rows from {2}", kRows, rowtype, path.ToUri()));
            }
            else
            {
                Channel.Error(result.Message);
            }

            return (true,kRows);
        }
    }
}