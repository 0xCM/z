//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedRules;

    partial class XedGrids
    {
        [MethodImpl(Inline)]
        public static FieldOp<T> operand<T>(FieldKind field, RuleOperator op, T value)
            where T : unmanaged, IValue<T>
                => new FieldOp<T>(field, op, value);

        [MethodImpl(Inline)]
        public static RuleOp<T> operand<T>(Nonterminal rule, RuleOperator op, T value)
            where T : unmanaged, IValue<T>
                => new RuleOp<T>(rule, op, value);

        [MethodImpl(Inline)]
        public static Cell<T> cell<T>(CellKey key, T value)
            where T : unmanaged,  IValue<T>, IEquatable<T>, ILogicOperand<T>
                => new Cell<T>(key,value);

        [MethodImpl(Inline)]
        public static GridCell cell(in RuleCell src)
            => new GridCell(src.Key, ColType.field(src.Field), src.Size, src.Value);

        public static Index<GridCell> cells(in CellRow src)
        {
            var count = src.CellCount;
            var dst = alloc<GridCell>(count);
            for(var i=0; i< count; i++)
                seek(dst,i) = cell(src[i]);
            return dst;
        }
    }
}