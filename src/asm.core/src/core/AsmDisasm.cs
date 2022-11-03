//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct AsmDisasm
    {
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
            Hex.render(LowerCase,(Hex64)src.Offset, ref i, dst);
            core.seek(dst,i++) = Chars.Space;
            text.copy(src.Statement.Data, ref i, dst);
            return i;
        }

        public static string format(in AsmDisasm src, Span<char> buffer)
        {
            var count = render(src,buffer);
            return text.format(core.slice(buffer,0,count));
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