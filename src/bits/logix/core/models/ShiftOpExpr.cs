//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a bitwise shift operator expression
    /// </summary>
    public readonly struct ShiftOpExpr<T> : IShiftOpExpr<T>
        where T : unmanaged
    {
        /// <summary>
        /// The operator kind
        /// </summary>
        public BitShiftClass ApiClass {get;}

        /// <summary>
        /// The operand
        /// </summary>
        public ILogixExpr<T> Subject {get;}

        /// <summary>
        /// The magnitude of the shift
        /// </summary>
        public ILogixExpr<byte> Offset {get;}

        [MethodImpl(Inline)]
        public ShiftOpExpr(BitShiftClass op, ILogixExpr<T> subject, ILogixExpr<byte> offset)
        {
            ApiClass = op;
            Subject = subject;
            Offset = offset;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => ApiClass == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => ApiClass != 0;
        }

        public string Format()
            => ApiClass.Format(Subject,Offset);

        public override string ToString()
            => Format();
    }
}