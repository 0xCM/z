//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedRules;

    partial class XedCmd
    {
        [CmdOp("xed/emit/layouts")]
        Outcome EmitLayouts(CmdArgs args)
        {
            var dst = hashset<LayoutCell>();
            var layouts = XedDb.CalcLayouts(Patterns);
            for(var i=0; i<layouts.LayoutCount; i++)
            {
                ref readonly var layout = ref layouts[i];
                for(var j=0; j<layout.Count; j++)
                {
                    ref readonly var cell = ref layout[j];
                    dst.Add(cell);
                }
            }

            var cells = dst.Array().Index();
            var distinct = dict<LayoutCellKind,List<LayoutCell>>();
            var kinds = Symbols.index<LayoutCellKind>().Kinds;
            for(var i=0; i<kinds.Length; i++)
                distinct[skip(kinds,i)] = new();

            for(var i=0; i<cells.Count; i++)
                distinct[cells[i].Kind].Add(cells[i]);

            var keys = distinct.Keys.Index();
            Index<LayoutCellKind,object> buffer = alloc<object>(keys.Length);
            for(var i=0; i<keys.Count; i++)
            {
                ref readonly var key = ref keys[i];
                var values = distinct[key].Index();
                switch(key)
                {
                    case LayoutCellKind.BL:
                        buffer[key] = values.Select(x => x.AsBitLit()).Sort();
                    break;
                    case LayoutCellKind.XL:
                        buffer[key] = values.Select(x => x.AsHexLit()).Sort();
                    break;
                    case LayoutCellKind.NT:
                        buffer[key] = values.Select(x => x.AsNonterm()).Sort();
                    break;
                    case LayoutCellKind.FS:
                        buffer[key] = values.Select(x => x.AsFieldSeg());
                    break;
                    case LayoutCellKind.SV:
                        buffer[key] = values.Select(x => x.AsSegVar());
                    break;
                    case LayoutCellKind.None:
                    break;
                    default:
                        Error($"{key}");
                    break;
                }
            }

            var formatter = CellRender.RenderFunctions;
            const string RenderPattern = "{0,-4} | {1,-4} | {2,-2} | {3,-32} | 0x{4,-8:X4} | {5,-22}";
            var output = text.emitter();
            var k=0u;
            for(var i = 0; i<keys.Count; i++)
            {
                ref readonly var key = ref keys[i];
                ref readonly var D = ref buffer[key];
                switch(key)
                {
                    case LayoutCellKind.BL:
                    {
                        var data = ((Index<uint5>)D).Sort();
                        for(var j=0; j<data.Length; j++, k++)
                        {
                            ref readonly var value = ref data[j];
                            output.AppendLineFormat(RenderPattern, k, j, key, formatter.Format((RuleCellKind)key, value), (byte)value, EmptyString);
                        }
                    }
                    break;
                    case LayoutCellKind.XL:
                    {
                        var data = (Index<Hex8>)D;
                        for(var j=0; j<data.Length; j++, k++)
                        {
                            ref readonly var value = ref data[j];
                            output.AppendLineFormat(RenderPattern, k, j, key, formatter.Format((RuleCellKind)key, value), (byte)value, EmptyString);
                        }
                    }
                    break;
                    case LayoutCellKind.NT:
                    {
                        var data = (Index<Nonterminal>)D;
                        for(var j=0; j<data.Length; j++, k++)
                        {
                            ref readonly var value = ref data[j];
                            output.AppendLineFormat(RenderPattern, k, j, key, formatter.Format((RuleCellKind)key, value), (ushort)value, EmptyString);
                        }
                    }
                    break;
                    case LayoutCellKind.FS:
                    {
                        var data = (Index<FieldSeg>)D;
                        for(var j=0; j<data.Length; j++, k++)
                        {
                            ref readonly var value = ref data[j];
                            output.AppendLineFormat(RenderPattern, k, j, key, formatter.Format((RuleCellKind)key, value), 0, value.Field);
                        }
                    }
                    break;
                    case LayoutCellKind.SV:
                    {
                        var data = (Index<SegVar>)D;
                        for(var j=0; j<data.Length; j++, k++)
                        {
                            ref readonly var value = ref data[j];
                            output.AppendLineFormat(RenderPattern, k, j, key, formatter.Format((RuleCellKind)key, value), 0, EmptyString);
                        }
                    }
                    break;
                }
            }


            Channel.FileEmit(output.Emit(),0,XedPaths.Target("xed.inst.layouts.test", FS.Csv));

            return true;
        }
   }
}