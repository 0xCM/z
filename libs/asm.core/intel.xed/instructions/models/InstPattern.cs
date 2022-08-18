//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    partial class XedRules
    {
        public class InstPattern : IComparable<InstPattern>
        {
            public static Index<InstPattern> load(Index<InstDef> defs)
            {
                var count = 0u;
                iter(defs, def => count += def.PatternSpecs.Count);
                var dst = alloc<InstPattern>(count);
                var k=0u;
                for(var i=0; i<defs.Count; i++)
                {
                    ref readonly var def = ref defs[i];
                    var specs = def.PatternSpecs;
                    for(var j=0; j<specs.Count; j++, k++)
                        seek(dst,k) = load(ref specs[j]);
                }
                return dst.Sort();
            }

            static InstPattern load(ref InstPatternSpec spec)
            {
                var fields = InstCells.sort(spec.Body.Cells);
                spec.Body = new (fields);
                return new InstPattern(spec, InstCells.usage(fields));
            }

            public readonly InstPatternSpec Spec;

            public readonly Index<OpName> OpNames;

            public readonly FieldSet FieldDeps;

            public readonly LockIndicator Lock;

            public readonly Index<InstOpDetail> OpDetails;

            public readonly InstCells Layout;

            public readonly InstCells Expr;

            public readonly bit Scalable;

            public InstPattern(in InstPatternSpec spec, FieldSet deps)
            {
                ref readonly var fields = ref spec.Body.Cells;
                var layout = fields.Layout;
                var expr = fields.Expr;
                Spec = spec;
                OpNames = spec.Ops.Names;
                FieldDeps = deps;
                Lock = InstCells.@lock(fields);
                OpDetails = XedOps.opdetails(this);
                Scalable = OpDetails.Any(x => x.Scalable);
                Layout = new InstCells(layout.ToArray(), (byte)layout.Length);
                Expr  = new InstCells(expr.ToArray(), 0);
            }

            public ref readonly InstPatternBody Body
            {
                [MethodImpl(Inline)]
                get => ref Spec.Body;
            }

            public ref readonly InstCells Cells
            {
                [MethodImpl(Inline)]
                get => ref Body.Cells;
            }

            public ref readonly MachineMode Mode
            {
                [MethodImpl(Inline)]
                get => ref Spec.Mode;
            }

            public ref readonly XedOpCode OpCode
            {
                [MethodImpl(Inline)]
                get => ref Spec.OpCode;
            }

            public TextBlock BodyExpr
            {
                [MethodImpl(Inline)]
                get => Spec.Body.Format();
            }

            public ref readonly TextBlock RawBody
            {
                [MethodImpl(Inline)]
                get => ref Spec.RawBody;
            }

            public ref readonly PatternOps Ops
            {
                [MethodImpl(Inline)]
                get => ref Spec.Ops;
            }

            [MethodImpl(Inline)]
            public ref readonly PatternOp Op(byte index)
                => ref Spec.Ops[index];

            public ref readonly PatternOp this[byte index]
            {
                [MethodImpl(Inline)]
                get => ref Op(index);
            }

            public ref readonly ushort PatternId
            {
                [MethodImpl(Inline)]
                get => ref @as<ushort>(Spec.Seq);
            }

            public ref readonly AsmInstClass InstClass
            {
                [MethodImpl(Inline)]
                get => ref Spec.InstClass;
            }

            public AsmInstClass Classifier
            {
                [MethodImpl(Inline)]
                get => InstClass;
            }

            public ref readonly InstForm InstForm
            {
                [MethodImpl(Inline)]
                get => ref Spec.InstForm;
            }

            public ref readonly InstIsa Isa
            {
                [MethodImpl(Inline)]
                get => ref Spec.Isa;
            }

            public ref readonly InstCategory Category
            {
                [MethodImpl(Inline)]
                get => ref Spec.Category;
            }

            public ref readonly Extension Extension
            {
                [MethodImpl(Inline)]
                get => ref Spec.Extension;
            }

            public ref readonly InstAttribs Attributes
            {
                [MethodImpl(Inline)]
                get => ref Spec.Attributes;
            }

            public ref readonly Index<XedFlagEffect> Effects
            {
                [MethodImpl(Inline)]
                get => ref Spec.Effects;
            }

            public int CompareTo(InstPattern src)
                => Sort().CompareTo(src.Sort());

            [MethodImpl(Inline)]
            public PatternSort Sort()
                => new PatternSort(this);

            public static InstPattern Empty => new InstPattern(InstPatternSpec.Empty, FieldSet.create());
        }
    }
}