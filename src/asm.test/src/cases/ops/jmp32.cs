//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    partial class AsmCases
    {
        // 7ffb6db4cab0h jmp near ptr 2ab9e80h                         # 0000h  | 5   | e9 7b 9e ab 02
        // 7ffb6dd70c38h jmp near ptr 2903798h                         # 0000h  | 5   | e9 93 37 90 02
        [Op]
        public static Index<JmpRel32> jmp32()
        {
            var dst = new JmpRel32();
            var cases = alloc<JmpRel32>(2);
            seek(cases,0) = jmp32("jmp near ptr 2ab9e80h", "e9 7b 9e ab 02", "7ffb6db4cab0h", "2ab9e80h");
            seek(cases,1) = jmp32("jmp near ptr 2903798h", "e9 93 37 90 02", "7ffb6dd70c38h", "2903798h");
            return cases;
        }

        static JmpRel32 jmp32(string statement, string encoding, string source, string target)
        {
            var dst = new JmpRel32();
            Require.invariant(DataParser.parse(source, out dst.Source), () => source);
            dst.Statment = statement;
            dst.Encoding = AsmHexApi.asmhex(encoding);
            dst.Disp = AsmRel.disp32(dst.Encoding.Bytes);
            Require.invariant(DataParser.parse(target, out dst.RelativeTarget), () => target);
            return dst;
        }
    }
}