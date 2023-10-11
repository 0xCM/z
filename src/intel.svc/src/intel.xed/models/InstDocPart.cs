//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;

partial class XedModels
{
    public class InstDocPart : IComparable<InstDocPart>
    {
        readonly InstPattern Inst;

        public InstDocPart(InstPattern src)
        {
            Inst = Require.notnull(src);
        }

        public ref readonly Index<OpName> OpNames
        {
            [MethodImpl(Inline)]
            get => ref Inst.OpNames;
        }

        public ref readonly PatternOps Ops
        {
            [MethodImpl(Inline)]
            get => ref Inst.Ops;
        }

        public ref readonly XedInstForm InstForm
        {
            [MethodImpl(Inline)]
            get => ref Inst.InstForm;
        }

        public XedInstClass Classifier
        {
            [MethodImpl(Inline)]
            get => Inst.Classifier;
        }

        public ref readonly AsmOpCode OpCode
        {
            [MethodImpl(Inline)]
            get => ref Inst.OpCode;
        }

        public ref readonly ushort PatternId
        {
            [MethodImpl(Inline)]
            get => ref Inst.PatternId;
        }

        public ref readonly InstCells Layout
        {
            [MethodImpl(Inline)]
            get => ref Inst.Layout;
        }

        public ref readonly InstCells Expr
        {
            [MethodImpl(Inline)]
            get => ref Inst.Expr;
        }

        public ref readonly MachineMode Mode
        {
            [MethodImpl(Inline)]
            get => ref Inst.Mode;
        }

        [MethodImpl(Inline)]
        public int CompareTo(InstDocPart src)
            => Inst.CompareTo(src.Inst);
    }
}
