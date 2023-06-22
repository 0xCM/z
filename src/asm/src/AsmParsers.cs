//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static sys;

    public class AsmParsers
    {
        public static bool parse(ReadOnlySpan<char> src, out InstructionId dst)
        {
            var input = text.trim(src);
            dst = InstructionId.Empty;
            if(input.Length != 24)
                return false;
            var x0 = slice(input,0,8);
            var result = HexParser.parse(x0, out Hex32 docid);
            if(!result)
                return result;

            var x1 = slice(input,8,16);
            result = HexParser.parse(x1, out Hex64 encid);
            if(!result)
                return result;

            dst = new InstructionId(docid, encid);
            return true;
        }
    }
}