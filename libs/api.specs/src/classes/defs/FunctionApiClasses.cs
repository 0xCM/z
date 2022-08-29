//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using I = IOperationClass<OperationKind>;
    using K = OperationKind;

    partial struct ApiClasses
    {
        public readonly struct EmitterFunc : I { public K Kind => K.Emitter; }

        public readonly struct UnaryFunc : I { public K Kind => K.UnaryFunc; }

        public readonly struct BinaryFunc : I { public K Kind => K.BinaryFunc; }

        public readonly struct TernaryFunc : I { public K Kind => K.TernaryFunc; }

        public readonly struct TernaryFunc<T> : IOperationClass<TernaryFunc,K,T> {}

        public readonly struct UnaryFunc<A,R> : IOperationClass<UnaryFunc,K,R> {}

        public readonly struct BinaryFunc<A,B,R> : IOperationClass<BinaryFunc,K,R> {}

        public readonly struct TernaryFunc<A,B,C,R> : IOperationClass<TernaryFunc,K,R> {}
    }
}