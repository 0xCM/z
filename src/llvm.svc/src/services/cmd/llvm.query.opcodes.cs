//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        [CmdOp("llvm/query/opcodes")]
        void QueryOpCodes()
        {
            const string RenderPattern = "{0,-8} | {1,-16} | {2,-32} | {3,-20} | {4}";
            var src = DataProvider.AsmOpCodeMap();
            var keys = src.Keys;
            var dst = text.emitter();
            dst.AppendLineFormat(RenderPattern, "Seq", "Map", "AsmId", "Bits", "Data");
            var seq=0u;
            for(var i=0; i<keys.Length; i++)
            {
                ref readonly var map = ref skip(keys,i);
                var mapped = src[map];
                for(var j=0; j<mapped.Count; j++, seq++)
                {
                    ref readonly var inst = ref mapped[j];
                    var data = text.remove(Fenced.unfence(inst.OpCodeData, Fenced.Embraced),Chars.Comma, Chars.Space);
                    BitsParser.parse(data, n8, out bits<byte> bits);
                    dst.AppendLineFormat(RenderPattern, seq, map, inst.InstName, bits, data);
                }
            }

            Query.FileEmit(dst.Emit(), "llvm.asm.opcodes", FS.Csv);
        }
    }
}