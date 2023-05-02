//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class NasmCatalog : WfSvc<NasmCatalog>
    {
        static bool comment(ReadOnlySpan<char> src)
            =>  src.Length != 0 && first(src) == Chars.Semicolon;

        static ReadOnlySpan<char> encoding(string src)
            => text.trim(text.replace(text.inside(src, Chars.LBracket, Chars.RBracket), Chars.Tab,Chars.Space));

        static ReadOnlySpan<char> operands(ReadOnlySpan<char> src)
        {
            var i0 = text.index(src,Chars.Tab, Chars.Space);
            if(i0 >0)
            {
                var i1 = text.index(src, i0 + 1, Chars.LBracket);
                if(i1 >0)
                    return SQ.segment(src,i0 + 1, i1 - 1).Trim();
            }
            return default;
        }

        public ReadOnlySpan<NasmInstruction> ParseInstructions(FilePath src)
        {
            const uint FirstLine = 70;
            var widths = SourceWidths;

            Channel.Babble(string.Format("Parsing {0}", src));
            if(!src.Exists)
            {
                Channel.Error(FS.missing(src));
                return default;
            }

            var input = src.ReadNumberedLines();
            if(input.Length < 80)
            {
                Channel.Error(string.Format("Bad format: {0}", src));
                return default;
            }

            Channel.Babble(string.Format("Read {0} source lines", input.Length));

            var lines = slice(input.View, FirstLine);
            var count = lines.Length;
            var section = EmptyString;
            var buffer = sys.alloc<NasmInstruction>(count);
            var j = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(lines,i);
                var content = text.replace(text.trim(line.Content), Chars.Pipe, Chars.Caret);

                if(content.Length < 2)
                    continue;

                if(comment(content))
                    continue;

                ref var dst = ref seek(buffer,j++);
                var pad = z16;
                var ws = SQ.wsix(content);
                dst.Sequence = j;
                dst.Mnemonic = text.left(content,ws);
                dst.Operands = sys.@string(operands(content));
                dst.Encoding = sys.@string(encoding(content));
                dst.Flags = content.RightOfFirst(Chars.RBracket).Trim().Replace(Chars.Tab, Chars.Space);
            }

            return slice(@readonly(buffer), 0, j);
        }

        static ReadOnlySpan<byte> SourceWidths => new byte[]{12,16,64,64,32};

        public ReadOnlySpan<NasmInstruction> RunEtl()
            => ImportInstructions(
                AppDb.DbSources().Path(FS.file("nasm.instructions", FS.Txt)),
                AppDb.AsmDb().Targets("asm.refs").Table<NasmInstruction>()
                );

        ReadOnlySpan<NasmInstruction> ImportInstructions(FilePath src, FilePath dst)
        {
            var instructions = ParseInstructions(src);
            Channel.TableEmit(instructions, dst, ASCI);
            return instructions;
        }
    }
}