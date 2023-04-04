//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class AsmObjects : AppService<AsmObjects>
    {
        AppDb AppDb => AppDb.Service;

        CoffServices Coff => Wf.CoffServices();

        IDbArchive EtlTargets(string name)
            => AppDb.EtlTargets(name);

        ObjDump ObjDump => Channel.Channeled<ObjDump>();

        public void RunEtl(ProjectContext context)
        {
            var project = context.Project.Name;
            EtlTargets(project).Delete();
            Channel.TableEmit(context.Files.Docs().Array().Sort().Resequence(), AppDb.EtlTable(project,"files.catalog"));
            var objects = ObjDump.CalcObjRows(context);
            Channel.TableEmit(objects, AppDb.EtlTable<ObjDumpRow>(project));
            var blocks = ObjDump.blocks(objects);
            Channel.TableEmit(blocks, AppDb.EtlTable<ObjBlockRow>(project));
            using var alloc = CompositeBuffers.create();
            ObjDump.MapAsm(context.Project, objects, alloc);
            var asmrows = ObjDump.EmitAsmRows(context, alloc);
            EmitRecoded(context, asmrows);
            var syms = ObjDump.CalcObjSyms(context);
            ObjDump.EmitObjSyms(context, syms);
            Coff.Collect(context);
            CollectAsmSyntax(context);
            CollectMcInstructions(context);
        }

        public McAsmDoc CalcMcAsmDoc(in FileRef src)
            => new LlvmAsmParser().ParseMcAsmDoc(src);

        public Index<McAsmDoc> CollectSyntaxDocs(ProjectContext context)
        {
            var src = SynAsmSources(context.Project).Array();
            var count = src.Length;
            var dst = list<McAsmDoc>();
            for(var i=0; i<count; i++)
                dst.Add(CalcMcAsmDoc(context.Doc(skip(src,i))));
            return dst.ToArray();
        }

        public Index<McAsmDoc> CalcMcAsmDocs(IProject src)
        {
            var files = FileCatalog.load(src.Files().Array().ToSortedSpan()).Docs(FileKind.McAsm);
            var count = files.Count;
            var dst = alloc<McAsmDoc>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = CalcMcAsmDoc(files[i]);
            return dst;
        }


        public IEnumerable<FilePath> SynAsmSources(IProject src)
            => src.BuildFiles(FileKind.SynAsm);

        public CoffSymIndex LoadSymbols(string id)
            => Coff.LoadSymIndex(id);

        public Index<ObjBlockRow> LoadBlocks(string id)
            => ObjDump.blocks(AppDb.EtlTable<ObjBlockRow>(id));

        public Index<AsmInstructionRow> LoadInstructions(string project)
        {
            const byte FieldCount = AsmInstructionRow.FieldCount;
            var src = AppDb.EtlTable<AsmInstructionRow>(project);
            var lines = slice(src.ReadNumberedLines().View,1);
            var count = lines.Length;
            var buffer = alloc<AsmInstructionRow>(count);
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
                result = DataParser.parse(skip(cells, j++), out dst.AsmName);
                result = AsmExpr.parse(skip(cells, j++), out dst.Asm);
                result = DataParser.parse(skip(cells, j++), out dst.Source);
            }
            return buffer;
        }

        public FilePath AsmInstructionTable(string name)
            => EtlContext.table<AsmInstructionRow>(name);

        public Index<AsmInstructionRow> CollectMcInstructions(ProjectContext context)
        {
            var project = context.Project;
            var result = Outcome.Success;
            var docs = CollectSyntaxDocs(context);
            var buffer = list<AsmInstructionRow>();
            var counter = 0u;
            foreach(var doc in docs)
            {
                var uri = doc.Path.ToUri();
                var origin = context.Root(doc.Path);
                var fref = context.Doc(doc.Path);
                var instructions = doc.Instructions;
                var srcLines = doc.SourceLines;
                var instLineNumbers = instructions.Keys.ToArray().Sort();
                var count = instLineNumbers.Length;
                for(var i=0; i<count; i++)
                {
                    ref readonly var number = ref skip(instLineNumbers, i);
                    var instruction = instructions[number];
                    var expr = srcLines[number];
                    var record = new AsmInstructionRow();
                    record.Seq = counter++;
                    record.OriginId = origin.DocId;
                    record.OriginName = origin.DocName;
                    record.DocSeq = instruction.DocSeq;
                    record.AsmName = instruction.AsmName;
                    record.Asm = expr.Statement.Format().Trim();
                    record.Source = uri.LineRef(number);
                    buffer.Add(record);
                }
            }

            var records = buffer.ToArray();
            Channel.TableEmit(records, AsmInstructionTable(project.Name));
            return records;
        }

        public IDbArchive RecodedTargets(string name)
            => AppDb.EtlTargets("mc.recoded").Targets(name);

        public FilePath RecodedTarget(string name, string origin)
            => RecodedTargets(name).Path(origin, FileKind.Asm);

        public FilePath AsmRowPath(string name, string origin)
            => AppDb.EtlTargets(name).Targets("asm.csv").Path(origin, FileKind.Csv);

        public void EmitRecoded(ProjectContext context, ReadOnlySeq<AsmCodeBlocks> blocks)
        {
            for(var i=0; i<blocks.Count; i++)
                RecodeBlocks(context.Project.Name, blocks[i]);
        }

        void RecodeBlocks(string name, in AsmCodeBlocks src)
        {
            const string intel_syntax = ".intel_syntax noprefix";
            var asmpath = RecodedTarget(name, src.OriginName.Format());
            var emitting = Channel.EmittingFile(asmpath);
            var counter = 0u;
            using var writer = asmpath.AsciWriter();
            writer.WriteLine(intel_syntax);
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var block = ref src[i];
                var label = new AsmBlockLabel(block.Label.Name.Format());
                writer.WriteLine();
                writer.WriteLine(label.Format());
                counter++;
                var count = block.Count;
                for(var j=0; j<count; j++)
                {
                    ref readonly var asmcode = ref block[j];
                    writer.WriteLine(string.Format("    {0,-48} # {1}", asmcode.Asm, asmcode.Encoding.FormatHex(Chars.Space, false)));
                }
            }

            Channel.EmittedFile(emitting,counter);
        }

        public FilePath AsmSyntaxTable(string name)
            => EtlContext.table<AsmSyntaxRow>(name);

        public Index<AsmSyntaxRow> CollectAsmSyntax(ProjectContext context)
        {
            var project = context.Project;
            var logs = project.BuildFiles(FileKind.SynAsmLog).Array();
            var dst = AsmSyntaxTable(project.Name);
            var count = logs.Length;
            var buffer = list<AsmSyntaxRow>();
            var seq = 0u;
            for(var i=0; i<count; i++)
                ParseAsmSyntaxRows(context, context.Doc(skip(logs,i)), buffer);
            var rows = buffer.ToArray().Sort();
            for(var i=0u; i<rows.Length; i++)
                seek(rows,i).Seq = i;
            Channel.TableEmit(@readonly(rows), dst);
            return rows;
        }

        public Index<Index<string>> CalcAsmSyntaxOps(ReadOnlySpan<AsmSyntaxRow> src)
        {
            var count = src.Length;
            var buffer = alloc<Index<string>>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref skip(src,i);
                var syntax = row.Syntax.Format();
                if(syntax.Contains(Chars.Colon))
                    seek(buffer,i) = text.trim(text.split(syntax, Chars.Space));
                else
                    seek(buffer,i) = sys.empty<string>();
            }

            return buffer;
        }

        static string syncontent(string src)
        {
            if(Fenced.test(src, Fenced.Paren))
                return text.trim(text.despace(Fenced.unfence(src, Fenced.Paren)));
            else
                return text.trim(text.despace(src));
        }

        void ParseAsmSyntaxRows(ProjectContext context, in FileRef src, List<AsmSyntaxRow> dst)
        {
            const string EntryMarker = "note: parsed instruction:";
            const string EncodingMarker = "# encoding:";
            const string ReplaceA = "{, ";
            const string ReplaceAWith = "{";
            const string ReplaceB = ", }";
            const string ReplaceBWith = "}";
            var ip = MemoryAddress.Zero;
            var lines = src.Path.ReadNumberedLines();
            var count = lines.Length;
            var docseq = 0u;
            for(var i=0; i<count-1; i++)
            {
                ref readonly var a = ref lines[i].Content;
                ref readonly var b = ref lines[i+1].Content;

                var m = text.index(a, EntryMarker);
                if(!a.Contains(EntryMarker))
                    continue;

                Fence<char> Brackets = (Chars.LBracket, Chars.RBracket);
                var locator = text.left(a,m).Trim();
                locator = text.slice(locator,0, locator.Length - 1);
                Archives.parse(locator, out FilePoint point);
                var srcpath = point.Path;
                var syntax = text.right(a, m + EntryMarker.Length);
                syntax = Fenced.unfence(syntax, Brackets, out var semantic) ? text.parenthetical(semantic) : syntax;
                var body = b.Replace(Chars.Tab, Chars.Space);
                var record = new AsmSyntaxRow();
                var orign = context.Root(src.Path);
                record.OriginId = orign.DocId;
                record.OriginName = orign.DocName;
                record.DocSeq = docseq++;
                record.Syntax = syncontent(syntax.Replace(ReplaceA, ReplaceAWith).Replace(ReplaceB, ReplaceBWith).Replace("Memory: ", "Mem:"));
                AsmMnemonic.parse(record.Syntax, out var mx);
                if(mx >=0)
                {
                    var s = record.Syntax.Format();
                    var mi = text.index(s, mx, Chars.Space);
                    if(mi > 0)
                        record.Syntax = text.right(s,mi);
                }

                var ci = text.index(body, Chars.Hash);
                if (ci > 0)
                    AsmExpr.parse(text.left(body, ci), out record.Asm);
                else
                    record.Asm = RP.Empty;

                var xi = text.index(body, EncodingMarker);
                if(xi > 0)
                {
                    var enc = text.right(body,xi + EncodingMarker.Length + 1);
                    if(AsmHexApi.parse(enc, out var encoding))
                    {
                        record.Encoded = encoding;
                        ip += encoding.Size;
                    }
                }

                record.Source = srcpath.ToUri().LineRef(point.Location.Line);
                dst.Add(record);
            }
        }

        public Index<AsmSyntaxOps> CalcSyntaxOps(ProjectId project)
        {
            var rows = LoadAsmSyntax(project);
            var count = rows.Count;
            var opLists = CalcAsmSyntaxOps(rows);
            var dst = alloc<AsmSyntaxOps>(count);
            Require.equal(count, opLists.Count);
            for(var i=0; i<count; i++)
                seek(dst,i) = new AsmSyntaxOps(rows[i],opLists[i]);
            return dst;
        }

        public Index<AsmSyntaxRow> LoadAsmSyntax(ProjectId project)
            => LoadSyntaxRows(AsmSyntaxTable(project));

        Index<AsmSyntaxRow> LoadSyntaxRows(FilePath src)
        {
            const byte FieldCount = AsmSyntaxRow.FieldCount;
            using var reader = src.Utf8LineReader();
            var rowcount = AsciLines.count(src).Lines - 1;
            var counter = 0u;
            var result = Outcome.Success;
            var buffer = alloc<AsmSyntaxRow>(rowcount);
            reader.Next(out _);
            while(reader.Next(out var line))
            {
                var cells = text.trim(text.split(line.Content, Chars.Pipe));
                var count = cells.Length;
                if(count != FieldCount)
                {
                    result = (false,Tables.FieldCountMismatch.Format(count,FieldCount));
                    break;
                }

                ref var dst = ref seek(buffer,counter++);
                var j=0;

                result = DataParser.parse(skip(cells,j++), out dst.Seq);
                result = DataParser.parse(skip(cells,j++), out dst.DocSeq);
                result = HexParser.parse(skip(cells,j++), out dst.OriginId);
                result = DataParser.parse(skip(cells,j++), out dst.OriginName);

                if(result.Fail)
                {
                    result = (false, string.Format("Line {0}, field {1}", line.LineNumber, nameof(dst.DocSeq)));
                    break;
                }

                dst.Asm = skip(cells, j++);
                dst.Syntax = skip(cells, j++);

                var hex = skip(cells, j++);
                if(empty(hex))
                {
                    dst.Encoded = AsmHexCode.Empty;
                    dst.Source = FilePath.Empty;
                    continue;
                }

                result = AsmHexApi.parse(hex, out dst.Encoded);
                if(result.Fail)
                {
                    result = (false, string.Format("Line {0}, field {1}", line.LineNumber, nameof(dst.Encoded)));
                    break;
                }

                result = DataParser.parse(skip(cells,j++), out dst.Source);
                if(result.Fail)
                {
                    result = (false, string.Format("Line {0}, field {1}", line.LineNumber, nameof(dst.Source)));
                    break;
                }
            }

            if(result)
            {
                return buffer;
            }
            else
            {
                Channel.Error(result.Message);
                return sys.empty<AsmSyntaxRow>();
            }
        }

        public static readonly Symbols<ObjSymCode> SymCodes;

        public static readonly Symbols<ObjSymKind> SymKinds;

        static AsmObjects()
        {
            SymCodes = Symbols.index<ObjSymCode>();
            SymKinds = Symbols.index<ObjSymKind>();
        }
    }
}