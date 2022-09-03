//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public void EmitInstGroups(Index<InstGroup> src)
        {
            iter(CalcInstGroupLookup(src,PllExec), kvp => Emit(kvp.Key, kvp.Value), PllExec);

            const string RenderPattern = "{0,-8} | {1,-12} | {2,-18} | {3,-8} | {4,-8} | {5,-6} | {6,-6} | {7,-6} | {8,-6} | {9,-26} | {10,-22} | {11}";
            var counter = 0u;
            var dst = text.buffer();
            var k=0u;
            dst.AppendLineFormat(RenderPattern, "Seq", "PatternId", "Instruction", "Mod", "Lock", "Mode", "RexW", "Rep", "Index", "OpCode", "OpCodeBytes", "Form");
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var group = ref src[i];
                var opcode = XedOpCode.Empty;
                foreach(var member in group.Members)
                {
                    if(opcode.IsEmpty)
                        opcode = member.OpCode;

                    if(opcode != member.OpCode)
                    {
                        dst.AppendLine();
                        opcode = member.OpCode;
                    }

                    dst.AppendLineFormat(RenderPattern,
                        k++,
                        member.PatternId,
                        member.Class,
                        member.Mod,
                        member.Lock,
                        member.Mode,
                        member.RexW,
                        member.Rep,
                        member.Index,
                        member.OpCode,
                        member.OpCode.Value,
                        member.InstForm
                        );

                    counter++;
                }

                dst.AppendLine();
            }
            FileEmit(dst.Emit(), counter, XedPaths.InstTarget("xed.inst.groups", FileKind.Csv));
        }
    }
}