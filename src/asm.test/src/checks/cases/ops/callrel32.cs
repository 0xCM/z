//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    partial class AsmCases
    {
        [Op]
        public static Index<CallRel32> callrel32(ISymbolDispenser symbols)
        {
            var block = symbols.Symbol(0x7ffe6818a0e0ul, "callrel32");
            var cases = alloc<CallRel32>(4);
            var buffer = span(cases);
            var index = 0u;
            const string Asm0 = "call 7ffe65135260h # 7ffe6818a108h 0028h | e8 53 b1 fa fc";
            load(block, 0x7ffe6818a108, 0x7ffe6818a10d, 0x7ffe65135260, "e8 53 b1 fa fc", Asm0, ref seek(buffer, index++));
            const string Asm1 = "call 7ffe65135268h # 7ffe6818a120h 0040h | e8 43 b1 fa fc";
            load(block, 0x7ffe6818a120, 0x7ffe6818a125, 0x7ffe65135268, "e8 43 b1 fa fc", Asm1, ref seek(buffer, index++));
            const string Asm2 = "call 7ffe65135270h # 7ffe6818a13bh 005bh | e8 30 b1 fa fc";
            load(block, 0x7ffe6818a13b, 0x7ffe6818a140, 0x7ffe65135270, "e8 30 b1 fa fc", Asm2, ref seek(buffer, index++));
            const string Asm3 = "call 7ffe65135278h # 7ffe6818a154h 0074h | e8 1f b1 fa fc";
            load(block, 0x7ffe6818a154, 0x7ffe6818a159, 0x7ffe65135278, "e8 1f b1 fa fc", Asm3, ref seek(buffer, index++));
            return cases;
        }

        static ref CallRel32 load(LocatedSymbol block, MemoryAddress ip, MemoryAddress rip, MemoryAddress target, AsmHexCode encoding, @string asm, ref CallRel32 dst)
        {
            dst.Block = block;
            dst.IP = ip;
            dst.RIP = rip;
            dst.Target = target;
            dst.Disp = (Disp32)((long)target - (long)rip);
            dst.Encoding = encoding;
            dst.Asm = asm;
            return ref dst;
        }
    }
}