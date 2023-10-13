//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedRules;

partial class XedModels
{
    public class InstPattern : IComparable<InstPattern>
    {
        public static Index<InstPatternRecord> records(Index<InstPattern> src, bool pll = true)
        {
            var count = src.Count;
            var dst = sys.bag<InstPatternRecord>();
            iter(src, p => dst.Add(record(p)), pll);
            var sorted = dst.Array().Sort(PatternSort.comparer());
            return sorted.Resequence();
        }

        static InstPatternRecord record(in InstPattern src)
        {
            ref readonly var body = ref src.Body;
            var dst = InstPatternRecord.Empty;
            dst.PatternId = src.PatternId;
            dst.OpCode = src.OpCode;
            dst.Mode = src.Mode;
            dst.Lock = src.Lock;
            dst.Scalable = src.Scalable;
            Require.invariant(src.InstClass.Kind != 0);
            dst.InstClass = Xed.classifier(src.InstClass);
            dst.InstForm = src.InstForm;
            dst.Body = body;
            return dst;
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
            ref readonly var fields = ref spec.Body;
            var layout = fields.Layout;
            var expr = fields.Expr;
            Spec = spec;
            OpNames = spec.Ops.Names;
            FieldDeps = deps;
            Lock = XedCells.@lock(fields);
            OpDetails = XedPatterns.opdetails(this);
            Scalable = OpDetails.Any(x => x.Scalable);
            Layout = new (layout.ToArray(), (byte)layout.Length);
            Expr  = new (expr.ToArray(), 0);
        }

        public ref readonly InstCells Body
        {
            [MethodImpl(Inline)]
            get => ref Spec.Body;
        }

        public ref readonly InstCells Cells
        {
            [MethodImpl(Inline)]
            get => ref Body;
        }

        public ref readonly MachineMode Mode
        {
            [MethodImpl(Inline)]
            get => ref Spec.Mode;
        }

        public ref readonly AsmOpCode OpCode
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

        public ref readonly XedInstClass InstClass
        {
            [MethodImpl(Inline)]
            get => ref Spec.InstClass;
        }

        public XedInstClass Classifier
        {
            [MethodImpl(Inline)]
            get => InstClass;
        }

        public ref readonly XedInstForm InstForm
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

        public ref readonly InstExtension Extension
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
            => new (this);

        public static InstPattern Empty => new (InstPatternSpec.Empty, FieldSet.create());
    }
}