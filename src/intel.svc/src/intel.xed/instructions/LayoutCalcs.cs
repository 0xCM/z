//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedModels;

partial class XedRules
{
    public readonly struct LayoutCalcs
    {
        public static InstLayouts layouts(ReadOnlySeq<InstPattern> src)
        {
            Require.invariant(src.IsNonEmpty);
            var count = src.Count;
            var blocks = NativeCells.alloc<InstLayoutBlock>(count, out var id);
            var size = InstLayoutBlock.Size;
            Index<InstLayout> dst = alloc<InstLayout>(count);
            var layouts = new InstLayouts(dst, blocks);
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                var segref = new SegRef<LayoutCell>(sys.address(blocks[i]), size);
                counter += layout(src[i], segref, out dst[i]);
                layouts.Record(i) = record(dst[i]);
            }

            return layouts;
        }

        public static uint layout(InstPattern src, SegRef<LayoutCell> block, out InstLayout dst)
        {
            ref readonly var fields = ref src.Layout;
            var count = Demand.lteq(fields.Count, InstLayoutRecord.CellCount);
            dst = new InstLayout((ushort)src.PatternId, src.InstClass, src.OpCode, count, block);
            for(var j=z8; j<fields.Count; j++)
                dst[j] = LayoutCell.from(fields[j]);

            return fields.Count;
        }

        public static InstLayoutRecord record(in InstLayout src)
        {
            var dst = InstLayoutRecord.Empty;
            dst.PatternId = (ushort)src.PatternId;
            dst.Instruction = src.Instruction;
            dst.OpCode = src.OpCode;
            dst.Count = Demand.lteq(src.Count, InstLayoutRecord.CellCount);
            for(var j=z8; j<src.Count; j++)
                assign(j, src[j], ref dst);
            return dst;
        }

        static void assign(byte index, in LayoutCell src, ref InstLayoutRecord dst)
        {
            switch(index)
            {
                case 0:
                    dst.Cell0 = src;
                break;
                case 1:
                    dst.Cell1 = src;
                break;
                case 2:
                    dst.Cell2 = src;
                break;
                case 3:
                    dst.Cell3 = src;
                break;
                case 4:
                    dst.Cell4 = src;
                break;
                case 5:
                    dst.Cell5 = src;
                break;
                case 6:
                    dst.Cell6 = src;
                break;
                case 7:
                    dst.Cell7 = src;
                break;
                case 8:
                    dst.Cell8 = src;
                break;
                case 9:
                    dst.Cell9 = src;
                break;
                case 10:
                    dst.Cell10 = src;
                break;
            }
        }
    }
}
