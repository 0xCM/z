//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using SQ = SymbolicQuery;
    using C = AsciCode;

    using static sys;

    [Record(TableId)]
    public struct AsmDisasm
    {
        static MsgPattern<C> MarkerCodeNotFound => "Markier '{0}' not found";

        readonly Index<char> _LineBuffer;

        public AsmDisasm()
        {
            _LineBuffer = alloc<char>(256);
        }

        Span<char> StatementBuffer()
            => _LineBuffer.Clear().Edit;

        public uint LineCount(ReadOnlySpan<byte> src)
            => AsciLines.count(recover<C>(src));

        public uint MaxLineLength(ReadOnlySpan<byte> src)
            => SQ.maxlength(recover<C>(src));

        public Outcome ProcessLine(ref AsciLineCover src, out AsmDisasm dst)
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

        public void ParseDisassembly(IWfChannel channel, FilePath src, FilePath dst)
        {
            using var map = MemoryFiles.map(src);
            var flow = channel.EmittingFile(dst);
            var outcome = TransformData(channel, map.View<byte>(), dst);
            channel.EmittedFile(flow, 0);
        }

        Outcome TransformData(IWfChannel channel, ReadOnlySpan<byte> src, FilePath dst)
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
                        channel.Error(string.Format("Error processing line {0}:{1} - {2}", number, line.Format(), outcome.Message));
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

        [MethodImpl(Inline), Op]
        public static AsmDisasm define(MemoryAddress offset, AsmExpr statement)
            => new AsmDisasm(offset, statement);

        public static string format(in AsmDisasm src)
        {
            var left = string.Format("{0,-12} {1,-64}", src.Offset, src.Statement);
            var right = new AsmComment(string.Format("{0,-32} {1}", src.Code, src.Bitstring));
            return string.Format("{0}{1}", left, right);
        }

        [Op]
        public static uint render(in AsmDisasm src, Span<char> dst)
        {
            var i=0u;
            HexRender.render(LowerCase,(Hex64)src.Offset, ref i, dst);
            sys.seek(dst,i++) = Chars.Space;
            text.copy(src.Statement.Data, ref i, dst);
            return i;
        }

        public static string format(in AsmDisasm src, Span<char> buffer)
        {
            var count = render(src,buffer);
            return text.format(sys.slice(buffer,0,count));
        }

        const string TableId = "asm.disassembly";

        [Render(16)]
        public MemoryAddress Offset;

        [Render(64)]
        public AsmExpr Statement;

        [Render(32)]
        public AsmHexCode Code;

        [Render(1)]
        public string Bitstring;

        [MethodImpl(Inline)]
        public AsmDisasm(MemoryAddress offset, AsmExpr expr, AsmHexCode code, string bs)
        {
            Offset = offset;
            Statement = expr;
            Code = code;
            Bitstring = bs;
        }

        [MethodImpl(Inline)]
        public AsmDisasm(MemoryAddress offset, AsmExpr expr)
        {
            Offset = offset;
            Statement = expr;
            Code = AsmHexCode.Empty;
            Bitstring = EmptyString;
        }
    }
}