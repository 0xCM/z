//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XedRules
    {
        public static Index<XedInstOpCode> poc(Index<InstPattern> src)
        {
            var count = src.Count;
            var buffer = alloc<XedInstOpCode>(count);

            for(var i=0u; i<count; i++)
            {
                ref var dst = ref seek(buffer,i);
                poc(src[i], out seek(buffer,i));
            }

            buffer.Sort(new PatternOrder(true));

            var oc = XedOpCode.Empty;
            var @class = XedInstClass.Empty;
            var oci = z8;
            for(var i=0u; i<count; i++)
            {
                ref var dst = ref seek(buffer,i);
                if(i == 0)
                {
                    oc = dst.OpCode;
                    @class = dst.InstClass;
                }

                if(oc != dst.OpCode || @class != dst.InstClass)
                {
                    oc = dst.OpCode;
                    @class = dst.InstClass;
                    oci = z8;
                }

                dst.Index = oci++;
            }

            buffer.Sort(new PatternOrder());
            for(var i=0u; i<count; i++)
                seek(buffer,i).Seq = i;

            return buffer;
        }

        static void poc(InstPattern src, out XedInstOpCode dst)
        {
            dst.Seq = 0u;
            dst.Index = z8;
            dst.PatternId = (ushort)src.PatternId;
            dst.MapName = AsmOpCodeMaps.name(src.OpCode.Kind);
            dst.Value = src.OpCode.Value;
            dst.InstClass = src.InstClass.Classifier;
            dst.Mode = InstCells.mode(src.Cells);
            dst.Lock = InstCells.@lock(src.Cells);
            dst.Mod = InstCells.mod(src.Cells);
            dst.RexW = InstCells.rexw(src.Cells);
            dst.Rep = InstCells.rep(src.Cells);
            dst.Layout = src.Layout;
            dst.Expr = src.Expr;
            dst.OpCode = src.OpCode;
        }
    }
}