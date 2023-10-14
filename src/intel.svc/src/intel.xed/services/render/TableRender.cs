//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;

partial struct XedCellRender
{
    public readonly struct Tables
    {
        public static string format(CellTables src)
        {
            var dst = text.emitter();
            var k=0u;
            render(src, ref k, dst);
            return dst.Emit();
        }

        public static string format(CellRow src)
        {
            var dst = text.emitter();
            var lix = 0u;
            render(src,ref lix, dst);
            return dst.Emit();
        }

        public static string format(CellTable src)
        {
            var dst = text.emitter();
            var lix = 0u;
            render(src, ref lix, dst);
            return dst.Emit();
        }

        public static uint render(Index<RuleCell> cells, ITextEmitter dst)
        {
            header(dst);
            for(var i=z16; i<cells.Count; i++)
            {
                ref readonly var cell = ref cells[i];
                dst.AppendLineFormat("{0:D5} | {1:D5} | {2,-48} | {3}", i, cell.Key.Index, cell.Key, cell.Format());
            }
            return cells.Count;
        }

        static void render(CellTables src, ref uint seq, ITextEmitter dst)
        {
            header(dst);
            for(var i=0; i<src.TableCount; i++)
                render(src[i], ref seq, dst);
        }

        [MethodImpl(Inline)]
        static void render(CellTable src, ref uint seq, ITextEmitter dst)
        {
            for(var i=0; i<src.RowCount; i++)
                render(src[i], ref seq, dst);
        }

        [MethodImpl(Inline)]
        static void render(CellRow src, ref uint seq, ITextEmitter dst)
        {
            for(var i=0; i<src.Count; i++, seq++)
            {
                ref readonly var cell = ref src[i];
                dst.AppendLineFormat("{0:D5} | {1,-48} | {2}", cell.Key.Index, cell.Key, cell);
            }
        }

        static void header(ITextEmitter dst)
            => dst.AppendLine(string.Format("{0,-5} | {1,-5} | {2,-48} | {3}", "Seq", "Lix", "Key", "Value"));
    }
}
