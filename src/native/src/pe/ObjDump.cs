//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static sys;
    using System.Linq;

    public class ObjDump : Channeled<ObjDump>
    {
        public Index<ObjSymRow> CalcObjSyms(ProjectContext context)
        {
            var result = Outcome.Success;
            var project = context.Project;
            var src = project.BuildFiles(FileKind.Sym).Array();
            var count = src.Length;
            var formatter = CsvTables.formatter<ObjSymRow>();
            var buffer = list<ObjSymRow>();
            var seq = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                var origin = context.Root(path);
                var fref = context.Doc(path);
                using var reader = path.Utf8LineReader();
                var counter = 0u;
                while(reader.Next(out var line))
                {
                    if(CoffObjects.parse(line.Content, ref counter, out var sym))
                    {
                        sym.Seq = seq++;
                        sym.OriginId = origin.DocId;
                        buffer.Add(sym);
                    }
                }
            }

            return buffer.ToArray();
        }

        public void EmitObjSyms(ProjectContext context, ReadOnlySpan<ObjSymRow> src)
            => Channel.TableEmit(src, AppDb.EtlTargets(context.Project.Name).Table<ObjSymRow>());

        public Index<ObjSymRow> LoadObjSyms(IProject project)
            => LoadObjSyms(AppDb.EtlTable<ObjSymRow>(project.Name));

        public Index<ObjSymRow> LoadObjSyms(FilePath src)
        {
            const byte FieldCount = ObjSymRow.FieldCount;
            var result = Outcome.Success;
            var lines = src.ReadLines(true);
            var count = lines.Count - 1;
            var dst = alloc<ObjSymRow>(count);
            var j=0;
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref lines[i+1];
                var cells = text.trim(text.split(line, Chars.Pipe));
                Require.equal(cells.Length,FieldCount);
                var reader = cells.Reader();
                ref var row = ref seek(dst,i);
                DataParser.parse(reader.Next(), out row.Seq).Require();
                DataParser.parse(reader.Next(), out row.DocSeq).Require();
                HexParser.parse(reader.Next(), out row.OriginId).Require();
                HexParser.parse(reader.Next(), out row.Offset).Require();
                SymCodes.ExprKind(reader.Next(), out row.Code);
                SymKinds.ExprKind(reader.Next(), out row.Kind);
                DataParser.parse(reader.Next(), out row.Name).Require();
                DataParser.parse(reader.Next(), out row.Source).Require();
            }

            return dst;
        }

        public Index<ObjDumpRow> LoadRows(string id)
            => ObjDump.rows(AppDb.EtlTable<ObjDumpRow>(id));

        public AsmCodeMap MapAsm(IProject project, CompositeBuffers dst)
        {
            var entries = map(project.Files(), LoadRows(project.Name), dst);
            Channel.TableEmit(entries, AppDb.EtlTable<AsmCodeMapEntry>(project.Name));
            return new AsmCodeMap(entries);
        }

        public AsmCodeMap MapAsm(IProject project, Index<ObjDumpRow> src, CompositeBuffers dst)
        {
            var entries = map(project.Files(), src, dst);
            Channel.TableEmit(entries, AppDb.EtlTable<AsmCodeMapEntry>(project.Name));
            return new AsmCodeMap(entries);
        }

        public Index<ObjDumpRow> CalcObjRows(ProjectContext context)
        {
            var project = context.Project;
            var src = context.Docs(FileKind.ObjAsm).Array().Sort().Index();
            var result = Outcome.Success;
            var formatter = CsvTables.formatter<ObjDumpRow>();
            var buffer = sys.bag<ObjDumpRow>();

            iter(src, member => {
                result = ObjDump.parse(context, member.Path, out var records);
                if(result.Fail)
                {
                    Channel.Error(result.Message);
                    return;
                }

                var docseq = 0u;
                for(var j=0; j<records.Count; j++)
                {
                    ref var record = ref records[j];
                    if(record.IsBlockStart)
                        continue;

                    buffer.Add(record);
                }
            }, true);

            return buffer.ToArray().Sort().Resequence();
        }

        public FilePath AsmRowPath(string name, string origin)
            => AppDb.EtlTargets(name).Targets("asm.csv").Path(origin, FileKind.Csv);

        public Index<AsmCodeBlocks> EmitAsmRows(ProjectContext context, CompositeBuffers alloc)
        {
            var files = context.Files.Docs(FileKind.ObjAsm);
            var count = files.Count;
            var seq = 0u;
            var dst = list<AsmCodeBlocks>();
            for(var i=0; i<count; i++)
            {
                ref readonly var file = ref files[i];
                var result = ObjDump.parse(context, file.Path, out var rows);
                if(result.Fail)
                    Errors.Throw(result.Message);

                var blocks = ObjDump.blocks(context, file, ref seq, rows, alloc);
                dst.Add(blocks);
                EmitAsmRows(context, blocks, AsmRowPath(context.Project.Name, file.Path.FileName.Format()));
            }
            return dst.ToArray();
        }

        public void EmitAsmRows(ProjectContext context, in AsmCodeBlocks src, FilePath dst)
        {
            var buffer = alloc<AsmCodeRow>(src.LineCount);
            var k=0u;
            var distinct = hashset<Hex64>();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var block = ref src[i];
                var count = block.Count;
                for(var j=0; j<count; j++, k++)
                {
                    ref readonly var code = ref block[j];
                    ref var record = ref seek(buffer,k);
                    record.Seq = k;
                    record.DocSeq = code.DocSeq;
                    record.EncodingId = code.EncodingId;
                    record.OriginId = code.OriginId;
                    record.InstructionId = asm.instid(code.OriginId, code.IP, code.Encoding);
                    record.OriginName = src.OriginName;
                    record.BlockBase = block.Label.Location;
                    record.BlockName = block.Label.Name;
                    record.IP = code.IP;
                    record.Size = code.Encoded.Size;
                    record.Encoded = code.Encoded;
                    record.Asm = code.Asm;
                    if(!distinct.Add(record.EncodingId))
                        Channel.Warn(string.Format("Duplicate identifier:{0}", record.EncodingId));
                }
            }

            Channel.TableEmit(buffer, dst);
        }

        public static AsmCode code(CompositeDispenser dispenser, in AsmEncodingInfo src)
        {
            ref readonly var code = ref src.Encoded;
            var size = code.Size;
            var hex = dispenser.Memory(size);
            var hexsrc = code.View;
            var hexdst = hex.Edit;
            for(var j=0; j<size; j++)
                seek(hexdst,j) = skip(hexsrc,j);
            return new AsmCode(EncodingId.from(src.IP, code), src.Seq, src.DocSeq, src.OriginId, dispenser.SourceText(src.Asm.Format()), src.IP, hex);
        }

        public static AsmCodeBlocks blocks(ProjectContext context, in FileRef file, ref uint seq, Index<ObjDumpRow> src, CompositeBuffers dispenser)
        {
            var blocks = src.GroupBy(x => x.BlockAddress).Array();
            var blockbuffer = alloc<AsmCodeBlock>(blocks.Length);
            var composite = dispenser.Composite();
            for(var i=0; i<blocks.Length; i++)
            {
                ref readonly var block = ref skip(blocks,i);
                var blockcode = block.Array();
                var blockname = first(blockcode).BlockName.Format();
                var blockaddress = block.Key;
                var codebuffer = alloc<AsmCode>(blockcode.Length);
                for(var k=0; k<blockcode.Length; k++)
                {
                    ref readonly var row = ref skip(blockcode,k);
                    var encoding = new AsmEncodingInfo();
                    encoding.Seq = seq++;
                    encoding.DocSeq = row.DocSeq;
                    encoding.EncodingId = row.EncodingId;
                    encoding.OriginId = row.OriginId;
                    encoding.InstructionId = row.InstructionId;
                    encoding.IP = row.IP;
                    encoding.Encoded = row.Encoded.Bytes;
                    encoding.Size = row.Size;
                    encoding.Asm = row.Asm.Content;
                    seek(codebuffer,k) = code(composite,encoding);
                }
                seek(blockbuffer,i) = new AsmCodeBlock(composite.Symbol(blockaddress,blockname), codebuffer);
            }
            var origin = context.Root(file.Path);
            return new AsmCodeBlocks(composite.Label(origin.DocName), origin.DocId, blockbuffer);
        }

        static Index<AsmCodeBlocks> blocks(IEnumerable<FilePath> files, Index<ObjDumpRow> rows, CompositeBuffers dispenser)
        {
            var collected = dict<uint, AsmCodeBlocks>();
            var groups = rows.GroupBy(x => x.OriginId).Array();
            var buffer = alloc<AsmCodeBlocks>(groups.Length);
            var composite = dispenser.Composite();
            for(var i=0; i<groups.Length; i++)
            {
                ref readonly var group = ref skip(groups,i);
                var blocks = group.ToArray().GroupBy(x => x.BlockName).Array();
                if(blocks.Length == 0)
                    continue;

                var blockbuffer = alloc<AsmCodeBlock>(blocks.Length);
                for(var j=0; j<blocks.Length; j++)
                {
                    ref readonly var block = ref skip(blocks,j);
                    var blockcode = block.Array();
                    if(blockcode.Length == 0)
                        continue;

                    var blockname = block.Key.Format();
                    var blockaddress = first(blockcode).BlockAddress;
                    var codebuffer = alloc<AsmCode>(blockcode.Length);
                    for(var k=0; k<blockcode.Length; k++)
                    {
                        ref readonly var row = ref skip(blockcode,k);
                        var encoding = new AsmEncodingInfo();
                        encoding.Seq = row.Seq;
                        encoding.DocSeq = row.DocSeq;
                        encoding.EncodingId = row.EncodingId;
                        encoding.OriginId = row.OriginId;
                        encoding.IP = row.IP;
                        encoding.Encoded = row.Encoded.Bytes;
                        encoding.InstructionId = row.InstructionId;
                        encoding.Size = row.Size;
                        encoding.Asm = row.Asm.Content;
                        seek(codebuffer,k) = code(composite,encoding);
                    }

                    seek(blockbuffer,j) = new AsmCodeBlock(composite.Symbol(blockaddress, blockname), codebuffer);
                }

                var origin = FileCatalog.load(files.Array().ToSortedSpan()).Doc(group.Key);
                seek(buffer,i) = new AsmCodeBlocks(composite.Label(origin.DocName), origin.DocId, blockbuffer);
            }
            return buffer;
        }

        public static Index<ObjBlockRow> blocks(FilePath path)
        {
            var lines = path.ReadLines(true);
            var reader = lines.Storage.Reader();
            reader.Next();
            var buffer = alloc<ObjBlockRow>(lines.Length - 1);
            var i=0u;
            while(reader.Next(out var line))
            {
                var cells = text.split(line,Chars.Pipe);
                Require.equal(ObjBlockRow.FieldCount, cells.Length);
                ref var dst = ref seek(buffer,i++);
                var src = cells.Reader();
                DataParser.parse(src.Next(), out dst.Seq).Require();
                DataParser.parse(src.Next(), out dst.BlockNumber).Require();
                HexParser.parse(src.Next(), out dst.OriginId).Require();
                DataParser.parse(src.Next(), out dst.BlockName).Require();
                DataParser.parse(src.Next(), out dst.BlockAddress).Require();
                DataParser.parse(src.Next(), out dst.BlockSize).Require();
                DataParser.parse(src.Next(), out dst.Source).Require();
            }
            return buffer;
        }

        public static Index<ObjBlockRow> blocks(Index<ObjDumpRow> src)
        {
            src.Sort();
            var count = src.Count;
            var seq = 0u;
            var docid = 0u;
            var docname = EmptyString;
            var blockname = EmptyString;
            var @base = MemoryAddress.Zero;
            var dst = list<ObjBlockRow>();
            var size = 0u;
            var number = 0u;
            var source = FilePath.Empty;
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref src[i];
                if(i==0)
                {
                    docid = row.OriginId;
                    blockname = row.BlockName;
                    source = row.Source;
                    docname = row.Source.FileName.Format();
                    @base = row.BlockAddress;
                }

                if(row.BlockName != blockname)
                {
                    var block = new ObjBlockRow();
                    block.Seq = seq++;
                    block.OriginId = docid;
                    block.BlockAddress = @base;
                    block.BlockName = blockname;
                    block.BlockNumber = number++;
                    block.BlockSize = size;
                    block.Source = source;
                    dst.Add(block);
                    size = 0;
                    source = row.Source;
                }

                if(row.OriginId != docid)
                    number = 0;

                docid = row.OriginId;
                blockname = row.BlockName;
                docname = row.Source.FileName.Format();
                @base = row.BlockAddress;
                size += row.Size;

                if(i==count-1)
                {
                    var block = new ObjBlockRow();
                    block.Seq = seq++;
                    block.OriginId = docid;
                    block.BlockName = blockname;
                    block.BlockAddress = @base;
                    block.BlockNumber = number++;
                    block.Source = source;
                    block.BlockSize = size;
                    dst.Add(block);
                }
            }

            return dst.ToArray();
        }        

        static Index<AsmCodeMapEntry> map(IEnumerable<FilePath> files, Index<ObjDumpRow> src, CompositeBuffers dispenser)
        {
            var distilled = blocks(files, src, dispenser);
            var entries = list<AsmCodeMapEntry>();
            for(var i=0; i<distilled.Count; i++)
            {
                ref readonly var blocks = ref distilled[i];
                if(blocks.Count == 0)
                    continue;

                var blocknumber = 0u;
                var @base = MemoryAddress.Zero;

                for(var j=0; j<blocks.Count; j++)
                {
                    ref readonly var block = ref blocks[j];
                    var count = block.Count;
                    ref readonly var address = ref block.Label.Location.Address;
                    ref readonly var name = ref block.Label.Name;
                    for(var k=0; k<count; k++)
                    {
                        ref readonly var c = ref block[k];

                        if(j==0 && k==0)
                            @base = c.Encoded.BaseAddress;

                        var entry = new AsmCodeMapEntry();
                        entry.Seq = c.Seq;
                        entry.DocSeq = c.DocSeq;
                        entry.EncodingId = c.EncodingId;
                        entry.OriginId = blocks.OriginId;
                        entry.InstructionId = asm.instid(blocks.OriginId, c.IP, c.Encoding);
                        entry.OriginName = blocks.OriginName;
                        entry.BlockNumber = blocknumber;
                        entry.BlockName = name;
                        entry.BlockAddress = address;
                        entry.IP = c.IP;
                        entry.Size = c.EncodingSize;
                        entry.Encoded = c.Encoded;
                        entry.Asm = c.Asm;
                        entry.BlockSize = block.Size;
                        entries.Add(entry);
                    }

                    blocknumber++;
                }
            }

            return entries.ToArray().Sort();
        }        
 
        public static Outcome parse(ProjectContext context, FilePath src, out Index<ObjDumpRow> dst)
            => new ObjDumpParser().Parse(context, src, out dst);

        public static Index<ObjDumpRow> rows(FilePath src)
        {
            var result = TextGrids.load(src, TextEncodingKind.Asci, out var grid);
            if(result.Fail)
                Errors.Throw(result.Message);

            var count = grid.RowCount;
            var buffer = alloc<ObjDumpRow>(count);
            ref var target = ref first(buffer);
            for(var i=0u; i<count; i++)
            {
                ref readonly var data = ref grid[(int)i];
                ref var dst = ref seek(target,i);
                var j=0;
                result = DataParser.parse(data[j++], out dst.Seq);
                result = DataParser.parse(data[j++], out dst.DocSeq);
                result = HexParser.parse(data[j++], out dst.OriginId);
                result = EncodingId.parse(data[j++].Text, out dst.EncodingId);
                result = AsmParsers.parse(data[j++].Text, out dst.InstructionId);
                result = DataParser.parse(data[j++], out dst.Section);
                result = DataParser.parse(data[j++], out dst.BlockAddress);
                result = DataParser.parse(data[j++], out dst.BlockName);
                result = AddressParser.parse(data[j++], out dst.IP);
                result = DataParser.parse(data[j++], out dst.Size);
                result = AsmHexApi.parse(data[j++].View, out dst.Encoded);
                dst.Asm = text.trim(data[j++].Text);
                result = AsmInlineComment.parse(data[j++].View, out dst.Comment);
                result = DataParser.parse(data[j++], out dst.Source);
            }

            return buffer;
        }

        static readonly Symbols<ObjSymCode> SymCodes;

        static readonly Symbols<ObjSymKind> SymKinds;

        static ObjDump()
        {
            SymCodes = Symbols.index<ObjSymCode>();
            SymKinds = Symbols.index<ObjSymKind>();
        }
    }
}