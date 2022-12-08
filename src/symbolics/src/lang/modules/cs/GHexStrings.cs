//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class GHexStrings : AppService<GHexStrings>
    {
        const string ArrayPackLine = "x{0:x}[{1:D5}:{2:D5}]={3}";

        [Op]
        public static string hexarray(in MemorySeg src, uint index, Span<char> dst)
        {
            var memory = src.ToSpan();
            var count = Hex.convert(memory.View, dst);
            return string.Format(ArrayPackLine, memory.BaseAddress, index, (uint)memory.Size, text.format(slice(dst, 0, count)));
        }

        [MethodImpl(Inline)]
        public static uint hexarray(W8 w, in MemoryBlock src, Span<char> dst)
            => Hex.convert(src.View, dst);


        static void EmitDelimiter(ITextBuffer dst)
            => dst.Append(", ");

        static void EmitDecl(uint indent, string name, ITextBuffer dst)
            => dst.IndentFormat(indent,"public static readonly string[] {0}", name);

        static void EmitInit(ulong count, ITextBuffer dst)
            => dst.AppendFormat(" = new string[{0}]", count);

        [MethodImpl(Inline)]
        static ulong count<T>(T min, T max)
            where T : unmanaged
                => bw64(max) - bw64(min) + 1;

        public void EmitArray<T>(uint indent, string name, T min, T max, LetterCaseKind @case, ITextBuffer dst)
            where T : unmanaged
        {
            EmitDecl(indent, name, dst);
            EmitInit(count(min,max),dst);
            dst.Append(Chars.LBrace);
            var _min = @bw64(min);
            var _max = @bw64(max);
            for(var i = _min; i<=_max; i++)
            {
                if(i != _min)
                    EmitDelimiter(dst);

                HexFormatter.quoted(@as<ulong,T>(i), @case, dst);
            }
            dst.Append(Chars.RBrace);
            dst.Append(Chars.Semicolon);
        }

        public string GenArray<T>(string name, T min, T max, LetterCaseKind @case)
            where T : unmanaged
        {
            var dst = text.buffer();
            EmitArray(0u, name, min,max,@case,dst);
            return dst.Emit();
        }
    }
}