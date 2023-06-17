//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    using static sys;

    public class CultProcessor : WfSvc<CultProcessor>
    {
        const uint BatchSize = Pow2.T16;

        List<CultSummary> Summaries;

        List<AsmSourceLine> AsmLines;

        Index<char> HexCharBuffer;

        FolderPath DetailRoot;

        const string cult = nameof(cult);

        public void RunEtl()
        {
            var src = AppDb.DbSources().Path(cult, FileKind.Asm);
            if(!src.Exists)
                Emitter.Error($"{src.ToUri()} has gone missing");
            else
            {
                var running = Emitter.Running($"Importing {src.ToUri()}");
                try
                {
                    var targets = AppDb.AsmDb().Targets(cult);
                    AsmLines = new();
                    Summaries = new();
                    DetailRoot = targets.Root + FS.folder("details");
                    HexCharBuffer = sys.alloc<char>(HexBufferLength);
                    RunEtl(src, targets);
                }
                catch(Exception e)
                {
                   Emitter.Error(e);
                }

                Ran(running);
            }
        }

        void RunEtl(FilePath src, IDbArchive dst)
        {            
            //var targets = AppDb.AsmDb().Targets(cult);
            // AsmLines = new();
            // Summaries = new();
            // DetailRoot = targets.Root + FS.folder("details");
            // HexCharBuffer = sys.alloc<char>(HexBufferLength);
            var output = span<CultRecord>(BatchSize);
            var input = span<TextLine>(BatchSize);
            using var reader = src.AsciReader();
            var counter = 0u;
            var current = 0;
            var max = BatchSize - 1;
            var batch = 0u;
            while(!reader.EndOfStream)
            {
                var line = reader.ReadLine(++counter);
                if(current < max)
                    seek(input, current++) = line;
                else
                {
                    Process(batch, counter, input, output);
                    output.Clear();
                    input.Clear();
                    current = 0;
                    batch++;
                }
            }

            if(current != 0)
                Process(batch, counter, input, output);

            EmitSummary(dst.Root + FS.file(cult + ".summary", FS.Csv));
        }

        uint Parse(ReadOnlySpan<TextLine> src, Span<CultRecord> dst)
        {
            var j=0u;
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var input = ref skip(src,i);
                if(Parse(input, out var record))
                    seek(dst, j++) = record;
            }
            return j;
        }

        void EmitSummary(FilePath dst)
            => TableEmit(Summaries.ViewDeposited(), dst);

        void Process(uint batch, uint counter, ReadOnlySpan<TextLine> src, Span<CultRecord> dst)
        {
            var processing = Channel.Running(ProcessingBatch.Format(batch, counter));
            var parsed = slice(dst, 0, Parse(src, dst));
            Process(parsed);
            Ran(processing, ProcessedBatch.Format(batch, counter, parsed.Length, BatchSize));
        }

        void Process(ReadOnlySpan<CultRecord> src)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var record = ref skip(src,i);
                if(record.RecordKind == CultRecordKind.Statement)
                {
                    AsmExpr.parse(record.Statement, out var expr);
                    AsmLines.Add(new AsmSourceLine(record.LineNumber, AsmLineClass.AsmSource, EmptyString, expr, new AsmComment(record.Comment)));
                }
                else if(record.RecordKind == CultRecordKind.Label)
                    AsmLines.Add(new AsmSourceLine(record.LineNumber, AsmLineClass.Label, record.Label.Format(), EmptyString, new AsmComment(record.Comment)));
                else if(record.RecordKind == CultRecordKind.Summary)
                {
                    var summary = Summarize(record);
                    Summaries.Add(summary);
                    EmitDetails(DetailRoot, summary);
                }
            }
        }

        void EmitDetails(FolderPath dir, in CultSummary summary)
        {
            var mnemonic = summary.Mnemonic.Format(MnemonicCase.Lowercase);
            var path = dir + DetailFile(mnemonic);
            using var writer = path.Writer(true);
            writer.WriteLine();
            writer.WriteLine(new AsmComment(summary.Id.Format()));
            writer.WriteLine(new AsmComment(PageBreak));

            if(AsmLines.Count != 0)
            {
                foreach(var line in AsmLines)
                {
                    var lf =  line.Format();
                    if(lf.StartsWith(summary.Mnemonic.Format(MnemonicCase.Lowercase) + Chars.Space))
                        writer.WriteLine(lf);
                }
                AsmLines.Clear();
            }
        }

        public bool Parse(TextLine src, out CultRecord dst)
        {
            dst = CultRecord.Empty;
            var result = true;
            var content = text.ifempty(src.Content,EmptyString);
            dst.LineNumber = src.LineNumber;
            var i = text.index(content, ": Lat:");
            var j = text.index(content, Chars.Colon);
            var k = text.index(content, Chars.Semicolon);
            if(i > 0)
            {
                ParseSummary(src, out dst);
            }
            else if(j > 0)
            {                
                var identifier = text.trim(content.LeftOfFirst(Chars.Colon));
                if(text.nonempty(identifier))
                    ParseLabel(src, identifier, out dst);

            }
            else if(k > 0)
            {
                var parts = @readonly(content.Split(Chars.Semicolon));
                ParseStatement(src, parts, out dst);
            }
            
            return result;
        }

        static CultSummary Summarize(in CultRecord src)
        {
            var dst = new CultSummary();
            metrics(src, out dst.Lat, out dst.Rcp);
            dst.Instruction = src.Comment.Format().LeftOfFirst(Chars.Colon).Trim();
            dst.Mnemonic = monic(dst.Instruction);
            dst.LineNumber = src.LineNumber;
            dst.Id = identify(dst);
            return dst;
        }

        static bool ParseLabel(TextLine src, string name, out CultRecord dst)
        {
            dst.LineNumber = src.LineNumber;
            dst.Label = name;
            dst.Statement = TextBlock.Empty;
            dst.Comment = TextBlock.Empty;
            dst.RecordKind = CultRecordKind.Label;
            return true;
        }

        bool ParseStatement(TextLine src, ReadOnlySpan<string> parts, out CultRecord dst)
        {
            var statement = skip(parts, 0).Remove(RexRemove);
            var comment = skip(parts, 1);
            var bitstring = RP.Error;
            var formatted = FormatBytes(comment, out var count);
            if(Hex.hexdata(formatted, out var parsed))
                bitstring = asm.asmhex(parsed).BitString;

            if(count != 0)
                comment = string.Format(StatementCommentPattern, comment, count, formatted, bitstring);

            dst.LineNumber = src.LineNumber;
            dst.Statement = statement;
            dst.Comment = comment;
            dst.Label = TextBlock.Empty;
            dst.RecordKind = CultRecordKind.Statement;
            return true;
        }

        static bool ParseSummary(TextLine src, out CultRecord dst)
        {
            dst.LineNumber = src.LineNumber;
            dst.Statement = TextBlock.Empty;
            dst.Comment = src.Content;
            dst.Label = TextBlock.Empty;
            dst.RecordKind = CultRecordKind.Summary;
            return true;
        }

        string FormatBytes(ReadOnlySpan<char> src, out uint size)
            => NormalizeBytes(src, out size).ToString();

        ReadOnlySpan<char> NormalizeBytes(ReadOnlySpan<char> src, out uint size)
        {
            var chars = HexCharBuffer.Edit;
            chars.Clear();
            var count = src.Length;
            var j=0;
            var k=0;
            var m=0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(Hex.scalar(c))
                {
                    seek(chars,j++) = c;
                    if(++k == 2)
                    {
                        seek(chars,j++) = Chars.Space;
                        k = 0;
                        m++;
                    }
                }
                else if(Hex.upper(c))
                {
                    seek(chars, j++) = Char.ToLowerInvariant(c);
                    if(++k == 2)
                    {
                        seek(chars,j++) = Chars.Space;
                        k = 0;
                        m++;
                    }
                }
            }
            size = m;
            if(size == 0)
              return default;
            else
            {
                var len = skip(chars,j-1) == Chars.Space ? j - 1 : j;
                return slice(chars,0,len);
            }
        }

        static string[] operands(string instruction)
            => instruction.RightOfFirst(Chars.Space).Split(Chars.Comma).Select(x => x.Trim());

        static FileName DetailFile(AsmMnemonic src)
            => FS.file(string.Format("cult.{0}", src.Format(MnemonicCase.Lowercase)), FS.Asm);

        static Identifier identify(in CultSummary src)
        {
            var individuals = operands(src.Instruction);
            var joined = individuals.Length != 0 ? individuals.Join(Chars.Underscore) : EmptyString;
            if(text.nonempty(joined))
                return string.Format("{0}_{1}", src.Mnemonic, joined);
            else
                return src.Mnemonic.Format(MnemonicCase.Lowercase);
        }

        //   adc r32, i32                            : Lat:   0.66 Rcp:   0.66

        static AsmMnemonic monic(string instruction)
            => instruction.LeftOfFirst(Chars.Space);

        static void metrics(in CultRecord src, out string lat, out string rcp)
        {
            var content = src.Comment.Format().RightOfFirst(Chars.Colon).Remove(LatMarker).Replace(RcpMarker,"|").SplitClean("|");
            lat = EmptyString;
            rcp = EmptyString;
            if(content.Length == 2)
            {
                lat = content[0].Trim();
                rcp = content[1].Trim();
            }
        }

        const byte HexBufferLength = 128;

        const string LatMarker = "Lat:";

        const string RcpMarker = "Rcp:";

        const string RexRemove = "rex ";

        const string PageBreak = RP.PageBreak160;

        const string StatementCommentPattern = "{0,-20} | {1,-6} | [{2} <-> {3}]";

        static MsgPattern<Count,Count> ProcessingBatch => "Processing batch {0:D2}:{1,-6}";

        static MsgPattern<Count,Count,Count,Count> ProcessedBatch => "Processed batch {0:D2}:{1,-6} ({2}/{3})";
    }
}