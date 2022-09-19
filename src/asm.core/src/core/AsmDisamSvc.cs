//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text;

    using static core;

    using SQ = SymbolicQuery;
    using C = AsciCode;

    using Asm;

    public class AsmDisamSvc : WfSvc<AsmDisamSvc>
    {
        readonly Index<char> _LineBuffer;

        public AsmDisamSvc()
        {
            _LineBuffer = alloc<char>(256);
        }

        public uint LineCount(ReadOnlySpan<byte> src)
            => AsciLines.count(recover<C>(src));

        public uint MaxLineLength(ReadOnlySpan<byte> src)
            => SQ.maxlength(recover<C>(src));

        Span<char> StatementBuffer()
            => _LineBuffer.Clear().Edit;

        public static MsgPattern<C> MarkerCodeNotFound => "Markier '{0}' not found";

        public Outcome ParseRawData(FilePath src)
        {
            const string Marker = "RAW DATA #";
            var result = Outcome.Success;
            var block = 0u;
            var offset = Hex32.Zero;
            var data = BinaryCode.Empty;
            var parsing = false;
            var records = list<HexCsvRow>();
            var formatter = Tables.formatter<HexCsvRow>(16);
            using var reader = src.LineReader(TextEncodingKind.Asci);
            while(reader.Next(out var line))
            {
                var content = line.Content;
                if(parsing)
                {
                    if(line.IsEmpty)
                    {
                        if(records.Count != 0)
                        {
                            iter(records, r => Write(formatter.Format(r)));
                            records.Clear();
                        }
                        parsing = false;
                    }
                    else
                    {
                        var i = text.index(content, Chars.Colon);
                        if(i<0)
                            return (false, "Unexpected content");

                        result = DataParser.parse(text.left(content,i), out offset);
                        if(result.Fail)
                            return (false, "Unable to parse offset");

                        result = DataParser.parse(text.right(content,i), out data);
                        if(result.Fail)
                            return result;
                    }
                }
                else
                {
                    var i = text.index(content,Marker);
                    if(i>0)
                    {
                        result = DataParser.parse(text.right(content,i), out block);
                        if(result.Fail)
                            return (false, "Unable to parse block number");
                        parsing = true;
                    }
                }
            }
            return result;
        }

        Outcome ProcessLine(ref AsciLineCover src, out AsmDisasm dst)
        {
            dst = default;
            var i = SQ.index(src.Codes, C.Colon);
            if(i == NotFound)
                return (false, MarkerCodeNotFound.Format(C.Colon));

            var left = slice(src.Codes, 0, i);
            var right = slice(src.Codes, i + 1);
            var j=0u;
            var result = Hex.parse(left,out ulong offset);
            if(!result)
                return (false, AppMsg.ParseFailure.Format(nameof(left), left.ToString()));

            var buffer = StatementBuffer();
            var count = text.render(right, ref j, buffer);
            dst = AsmDisasm.define(offset, text.format(slice(buffer,0,count)));
            return true;
        }

        public void ParseDisassembly(FilePath src, FilePath dst)
        {
            using var map = MemoryFiles.map(src);
            var flow = EmittingFile(dst);
            var outcome = TransformData(map.View<byte>(), dst);
            EmittedFile(flow, 0);
        }

        Outcome TransformData(ReadOnlySpan<byte> src, FilePath dst)
        {
            var lines = LineCount(src);
            var size = (ByteSize)src.Length;
            var max = MaxLineLength(src);
            using var writer = dst.Writer(Encoding.ASCII);
            Span<char> buffer = alloc<char>(max);
            var pos = 0u;
            var length = 0u;
            var offset = 0u;
            var number = 0u;
            while(pos++ < size -1)
            {
                ref readonly var a0 = ref skip(src, pos);
                ref readonly var a1 = ref skip(src, pos + 1);
                if(SQ.eol(a0,a1))
                {
                    var line = AsciLines.asci(src, offset, length + 1);
                    number++;
                    if(!SQ.contains(line.Codes, C.Colon) || number < 4)
                    {
                        pos++;
                        length = 0;
                        offset = pos;
                        continue;
                    }

                    var outcome = ProcessLine(ref line, out var content);
                    if(outcome.Fail)
                    {
                        Wf.Error(string.Format("Error processing line {0}:{1} - {2}", number, line.Format(), outcome.Message));
                        break;
                    }
                    buffer.Clear();
                    writer.WriteLine(AsmDisasm.format(content,buffer));
                    pos++;
                    length = 0;
                    offset = pos;
                }
                else
                    length++;
            }

            return true;
        }
    }
}