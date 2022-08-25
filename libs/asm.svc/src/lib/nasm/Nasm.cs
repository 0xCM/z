//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public sealed partial class Nasm : ToolService<Nasm>
    {
        readonly BitFormatter<byte> BitFormat;

        public FS.FilePath ListPath(FS.FolderPath dst, Identifier name)
            => dst + FS.file(name + ".bin", ListingExt);

        public FS.FileExt ListingExt
            => FS.ext("list") + FS.Asm;

        public Index<AssembledAsm> LoadAssembledAsm(FS.FolderPath src, Identifier listname)
            => Assembled(LoadListedBlocks(ListPath(src, listname)));

        public NasmCaseScript CreateCaseScript(Identifier name, FS.FolderPath dst)
        {
            var @case = new NasmCase();
            @case.CaseId = name;
            @case.SourcePath = input(dst,  FS.file(name.Format(), FS.Asm));
            @case.BinPath = output(dst, FS.file(name.Format(), FS.Bin));
            @case.ListPath = FS.path(string.Format("{0}.list.asm", @case.BinPath));
            return CreateCaseScript(@case, Script(dst, FS.file(name.Format(), FS.Cmd)));
        }

        public NasmCaseScript CreateCaseScript(NasmCase src, FS.FilePath dst)
        {
            var buffer = text.buffer();
            buffer.AppendLine("@echo off");
            buffer.AppendLineFormat("set SrcId={0}", src.CaseId);
            buffer.AppendLineFormat("set SrcPath={0}", format(src.SourcePath));
            buffer.AppendLineFormat("set BinPath={0}", format(src.BinPath));
            buffer.AppendLineFormat("set ListPath={0}", format(src.ListPath));
            buffer.AppendLineFormat("set tool={0}", format(ToolPath()));
            buffer.AppendLine("set CmdSpec=%tool% %SrcPath% -o %BinPath% -f bin -l %ListPath%");
            buffer.AppendLine("echo CmdSpec:%CmdSpec%");
            buffer.AppendLine("%CmdSpec%");
            dst.Overwrite(buffer.Emit());
            return script(src, dst);
        }
        public Nasm()
            : base("nasm")
        {
            BitFormat = BitRender.formatter<byte>(4);
        }

        public ref AssembledAsm Assembled(in NasmEncoding src, out AssembledAsm dst)
        {
            dst.Bitstring = FormatBitstring(src.Encoded);
            dst.Id = EncodingId.from(src.Offset, src.Encoded);
            dst.IP = src.Offset;
            dst.Encoded = src.Encoded;
            AsmExpr.parse(src.SourceText, out dst.Asm);
            dst.SourceLine = src.LineNumber;
            return ref dst;
        }

        public Index<AssembledAsm> Assembled(ReadOnlySpan<NasmCodeBlock> blocks)
        {
            var dst = list<AssembledAsm>();
            var count = blocks.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var block = ref skip(blocks,i);
                var code = block.Code.View;
                for(var j=0; j<code.Length; j++)
                    dst.Add(Assembled(skip(code,j), out var a));
            }
            return dst.ToArray();
        }
 
         [Op]
        public NasmListing ReadListing(FS.FilePath src)
        {
            var flow = Wf.Running(ReadingNasmListing.Format(src));
            var dst = list<NasmListLine>();
            using var reader = src.Utf8Reader();
            var i = 1u;
            while(!reader.EndOfStream)
                dst.Add(new NasmListLine(new TextLine(i++, reader.ReadLine())));
            var lines = dst.ToArray();
            Wf.Ran(flow, ReadNasmListing.Format(lines.Length, src));
            return new NasmListing(src, lines);
        }
        public uint ParseListing(NasmListing src, Span<NasmListEntry> dst)
        {
            var flow = Wf.Running(ParsingNasmListEntries.Format(src.LineCount));
            var j = 0u;
            var lines = src.Lines.View;
            var count = lines.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(lines,i);
                var outcome = Nasm.entry(line, out var entry);
                if(outcome)
                    seek(dst, j++) = entry;
                else
                    Wf.Warn(outcome.Message);
            }

            Wf.Ran(flow, ParsedNasmListEntries.Format(j));
            return j;
        }
 
         const string RenderDelimiter = RpOps.SpacedPipe;

        public string FormatBitstring(in BinaryCode src)
            => BitFormat.Format(src.Storage.Reverse());

        [Op]
        public void RenderCodeBlock(in NasmCodeBlock src, ITextBuffer dst)
        {
            if(src.Label.IsNonEmpty)
            {
                RenderLabel(src.Label, dst);
                dst.AppendLine();
            }

            var encodings = src.Code.View;
            var count = encodings.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var encoding = ref skip(encodings,i);
                dst.AppendFormat("{0,-8}", encoding.LineNumber);
                dst.AppendFormat("{0}{1,-16}", RenderDelimiter, encoding.Offset);
                dst.AppendFormat("{0}{1,-46}", RenderDelimiter, encoding.SourceText);
                dst.AppendFormat("{0}{1,-24}", RenderDelimiter, encoding.Encoded);
                dst.AppendFormat("{0}{1,-48}", RenderDelimiter, FormatBitstring(encoding.Encoded));
                dst.AppendLine();
            }
        }

        [Op]
        public void RenderLabel(in NasmLabel src, ITextBuffer dst)
        {
            dst.AppendFormat("{0,-8}", src.LineNumber);
            dst.AppendFormat("{0}{1}", RenderDelimiter, src.Name);
        }

        [Op]
        public void RenderLabel(in Identifier src, ITextBuffer dst)
        {
            dst.AppendFormat("{0}{1,-16}", RenderDelimiter, EmptyString);
            dst.AppendFormat("{0}{1,-24}", RenderDelimiter, EmptyString);
            dst.AppendFormat("{0}{1,-48}", RenderDelimiter, EmptyString);
            dst.AppendFormat("{0}{1}", RenderDelimiter, src);
        }

        [Op]
        public void RenderListEntry(in NasmListEntry src, ITextBuffer dst)
        {
            dst.AppendFormat("{0,-8}", src.LineNumber);
            var kind = Nasm.kind(src);

            if(kind == NasmListLineKind.Label)
                RenderLabel(src.Label, dst);
            else
            {
                dst.AppendFormat("{0}{1,-16}", RenderDelimiter, src.Offset);
                dst.AppendFormat("{0}{1,-24}", RenderDelimiter, src.Encoding);

                if(kind == NasmListLineKind.Encoding)
                    dst.AppendFormat("{0}{1,-48}", RenderDelimiter, FormatBitstring(src.Encoding));
                else
                    dst.AppendFormat("{0}{1,-48}", RenderDelimiter, EmptyString);

                dst.AppendFormat("{0}{1}", RenderDelimiter, src.SourceText);
            }
        }


        public Index<NasmCodeBlock> LoadListedBlocks(FS.FilePath path)
        {
            if(!path.Exists)
            {
                Wf.Error(FS.Msg.DoesNotExist.Format(path));
                return Index<NasmCodeBlock>.Empty;
            }

            var flow = Wf.Running(string.Format("Listing blocks from {0}", path.ToUri()));
            var listing = ReadListing(path);
            var buffer = alloc<NasmListEntry>(listing.LineCount);
            var count = ParseListing(listing, buffer);
            var output = slice(span(buffer), 0, count);
            var blocks = list<NasmEncodingBlocks>();
            var collector = new NasmEncodingBlocks(NasmLabel.Empty, new());
            for(var i=0; i<count; i++)
            {
                ref readonly var entry = ref skip(output,i);
                var kind = Nasm.kind(entry);
                if(kind == NasmListLineKind.Label)
                {
                    var label = new NasmLabel(entry.LineNumber, entry.Label);
                    if(collector.IsNonEmpty)
                        blocks.Add(collector);
                    collector = new NasmEncodingBlocks(label, new());

                }
                else if(kind == NasmListLineKind.Encoding)
                {
                    var encoding = new NasmEncoding();
                    encoding.Encoded = entry.Encoding;
                    encoding.LineNumber = entry.LineNumber;
                    encoding.Offset  = entry.Offset;
                    encoding.SourceText = entry.SourceText;
                    collector.Code.Add(encoding);
                }
            }
            if(collector.IsNonEmpty)
                blocks.Add(collector);
            var results = blocks.Map(x => x.ToBlock());
            Wf.Ran(flow, string.Format("Constructed {0} blocks from {1}", results.Length, path.ToUri()));
            return results;
        }

        static MsgPattern<Count> ParsingNasmListEntries => "Parsing list entries from {0} lines";

        public static MsgPattern<Count> ParsedNasmListEntries => "Parsing {0} list entries";

        public static MsgPattern<FileUri> ReadingNasmListing => "Reading nasm listing from {0}";

        public static MsgPattern<Count,FileUri> ReadNasmListing => "Read {0} nasm list lines from {1}";
   }
}