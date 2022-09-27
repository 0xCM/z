//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedRules;
    using static XedFields;
    using static XedDisasmModels;

    using K = XedRules.FieldKind;

    partial class XedDisasm
    {
        public const string RenderCol2 = FieldRender.Columns;

        public readonly struct FieldEmitter
        {
            readonly HashSet<FieldKind> Exclusions;

            readonly FieldRender Render;

            public FieldEmitter()
            {
                Exclusions = hashset<FieldKind>(K.TZCNT,K.LZCNT,K.MAX_BYTES);
                Render = XedFields.render();
            }

            public uint EmitFields(Detail src, ITextEmitter dst)
            {
                var fields = XedDisasm.fields();
                ref readonly var data = ref src.DataFile;
                dst.AppendLineFormat(RenderCol2, "DataSource", src.Source.Path.ToUri().Format());
                var counter = 0u;
                for(var i=0u; i<data.LineCount; i++)
                {
                    ref readonly var block = ref src[i];
                    XedDisasm.fields(block, ref fields);

                    dst.AppendLine(RpOps.PageBreak240);
                    dst.AppendLine(block.Lines.Format());
                    dst.AppendLine(RpOps.PageBreak100);

                    XedRender.describe(fields, dst);
                    dst.AppendLine(RpOps.PageBreak100);

                    var kinds = fields.Selected;
                    for(var k=0; k<kinds.Length; k++)
                    {
                        ref readonly var kind = ref skip(kinds,k);
                        if(Exclusions.Contains(kind))
                            continue;

                        dst.AppendLineFormat(RenderCol2, kind, Render[kind](fields.Fields[kind]));
                        counter++;
                    }

                    XedOps.render(block.Ops.Map(o => o.Spec), dst);
                    if(i!=data.LineCount -1)
                        dst.AppendLine();
                }

                return counter;
            }
        }
    }
}