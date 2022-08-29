//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = ApiOperatorKind;

    public readonly struct OperatorClass : IOperatorClass<OperatorClass,K>
    {
        public K Kind {get;}

        [MethodImpl(Inline)]
        public OperatorClass(K k)
            => Kind = k;

        public OperatorClass Classifier
        {
            [MethodImpl(Inline)]
            get => new OperatorClass(Kind);
        }
    }

    public readonly struct OperatorClass<T> : IOperationClass<ApiOperatorKind,T>
    {
        public ApiOperatorKind Kind {get;}

        [MethodImpl(Inline)]
        public OperatorClass(ApiOperatorKind k)
            => Kind = k;

        [MethodImpl(Inline)]
        public static implicit operator OperatorClass(OperatorClass<T> src)
            => new OperatorClass(src.Kind);
    }
}