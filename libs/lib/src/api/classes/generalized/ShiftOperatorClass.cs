//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ShiftOperatorClass : IOperatorClass<ShiftOperatorClass,ApiOperatorKind>
    {
        public static implicit operator OperatorClass(ShiftOperatorClass src)
            => src.Classifier;

        public ApiOperatorKind Kind
            => ApiOperatorKind.ShiftOp;

        public OperatorClass Classifier
            => new OperatorClass(Kind);
    }

    public readonly struct ShiftOperatorClass<T> : IOperatorClass<ShiftOperatorClass<T>,ApiOperatorKind,T>
    {
        [MethodImpl(Inline)]
        public static implicit operator OperatorClass<T>(ShiftOperatorClass<T> src)
            => src.Classifier;

        [MethodImpl(Inline)]
        public static implicit operator ShiftOperatorClass(ShiftOperatorClass<T> src)
            => src.NonGeneric;

        public ApiOperatorKind Kind
            => ApiOperatorKind.ShiftOp;

        public OperatorClass<T> Classifier
            => new OperatorClass<T>(Kind);

        public ShiftOperatorClass NonGeneric
            => default;
    }
}