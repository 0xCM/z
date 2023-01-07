//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text;

    using static sys;

    using C = AsciCode;

    public class AsciProcessor<T>
    {
        readonly Index<char> _LineBuffer;

        readonly Func<MemoryAddress,uint,T> F;

        readonly IWfChannel Channel;

        public AsciProcessor(IWfChannel channel,  uint buffer, Func<MemoryAddress,uint,T> f)
        {
            Channel = channel;
            F = f;
            _LineBuffer = alloc<char>(buffer);
        }

        public uint LineCount(ReadOnlySpan<byte> src)
            => AsciLines.count(recover<AsciCode>(src));

        public uint MaxLineLength(ReadOnlySpan<byte> src)
            => SQ.maxlength(recover<AsciCode>(src));

        bool ProcessLine(ref AsciLineCover src, out T dst)
        {
            dst = default;
            var i = SQ.index(src.Codes, C.Colon);
            if(i == NotFound)
                return false;

            var left = slice(src.Codes, 0, i);
            var right = slice(src.Codes, i + 1);
            var j=0u;
            var result = Hex.parse(left,out ulong offset);
            if(!result)
                return result;

            var buffer = StatementBuffer();
            var count = text.render(right, ref j, buffer);
            dst = F(offset,count);
            return true;
        }

        bool TransformData(ReadOnlySpan<byte> src, FilePath dst)
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
                    if(!outcome)
                    {
                        Channel.Error(string.Format("Error processing line {0}:{1}", number, line.Format()));
                        break;
                    }
                    buffer.Clear();
                    pos++;
                    length = 0;
                    offset = pos;
                }
                else
                    length++;
            }

            return true;
        }

        Span<char> StatementBuffer()
            => _LineBuffer.Clear().Edit;
    }
}