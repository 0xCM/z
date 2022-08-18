//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a type-level lift for the <see cref='ApiOperatorKind.BinaryOp'/> classifier
    /// </summary>
    public readonly struct BinaryOperatorClass : IOperatorClass<BinaryOperatorClass,ApiOperatorKind>
    {
        public static implicit operator OperatorClass(BinaryOperatorClass src)
            => src.Classifier;

        public ApiOperatorKind Kind
            => ApiOperatorKind.BinaryOp;

        public OperatorClass Classifier
        {
            [MethodImpl(Inline)]
            get => new OperatorClass(Kind);
        }
    }

    /// <summary>
    /// Defines an operand-parametric type-level lift for the <see cref='ApiOperatorKind.BinaryOp'/> classifier
    /// </summary>
    public readonly struct BinaryOperatorClass<T> : IOperatorClass<BinaryOperatorClass<T>,ApiOperatorKind,T>
    {
        public ApiOperatorKind Kind
            => ApiOperatorKind.BinaryOp;

        [MethodImpl(Inline)]
        public static implicit operator OperatorClass<T>(BinaryOperatorClass<T> src)
            => src.Classifier;

        [MethodImpl(Inline)]
        public static implicit operator BinaryOperatorClass(BinaryOperatorClass<T> src)
            => src.Untyped;

        public OperatorClass<T> Classifier
        {
            [MethodImpl(Inline)]
            get => new OperatorClass<T>(Kind);
        }

        public BinaryOperatorClass Untyped
            => default;
    }
}