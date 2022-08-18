//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct UnaryOperatorClass : IOperatorClass<UnaryOperatorClass,ApiOperatorKind>
    {
        [MethodImpl(Inline)]
        public static implicit operator OperatorClass(UnaryOperatorClass src)
            => src.Classifier;

        public ApiOperatorKind Kind
            => ApiOperatorKind.UnaryOp;

        public OperatorClass Classifier
        {
            [MethodImpl(Inline)]
            get => new OperatorClass(Kind);
        }
    }

    public readonly struct UnaryOperatorClass<T> : IOperatorClass<UnaryOperatorClass<T>, ApiOperatorKind,T>
    {
        public ApiOperatorKind Kind
            => ApiOperatorKind.UnaryOp;

        public OperatorClass<T> Classifier
        {
            [MethodImpl(Inline)]
            get => new OperatorClass<T>(Kind);
        }

        public UnaryOperatorClass Untyped
            => default;

        [MethodImpl(Inline)]
        public static implicit operator OperatorClass<T>(UnaryOperatorClass<T> src)
            => src.Classifier;

        [MethodImpl(Inline)]
        public static implicit operator UnaryOperatorClass(UnaryOperatorClass<T> src)
            => src.Untyped;
    }
}