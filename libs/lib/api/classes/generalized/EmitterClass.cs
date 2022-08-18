//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct EmitterClass : IOperatorClass<EmitterClass,ApiOperatorKind>
    {
        public ApiOperatorKind Kind
            => ApiOperatorKind.Emitter;

        [MethodImpl(Inline)]
        public static implicit operator OperatorClass(EmitterClass src)
            => src.Classifier;

        public OperatorClass Classifier
        {
            [MethodImpl(Inline)]
            get => new OperatorClass(Kind);
        }
    }

    public readonly struct EmitterClass<T> : IOperatorClass<EmitterClass<T>,ApiOperatorKind,T>
    {
        public ApiOperatorKind Kind
            => ApiOperatorKind.Emitter;

        public OperatorClass<T> Classifier
        {
            [MethodImpl(Inline)]
            get => new OperatorClass<T>(Kind);
        }

        public EmitterClass Untyped
            => default;

        [MethodImpl(Inline)]
        public static implicit operator OperatorClass<T>(EmitterClass<T> src)
            => src.Classifier;

        [MethodImpl(Inline)]
        public static implicit operator EmitterClass(EmitterClass<T> src)
            => src.Untyped;
    }
}