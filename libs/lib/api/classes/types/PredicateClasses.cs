//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = PredicateKind;

    partial struct ApiClasses
    {
        public readonly struct PredicateClass : IOperationClassHost<PredicateClass,K> { public K Kind => K.Predicate; }

        public readonly struct UnaryPredicate : IOperationClassHost<UnaryPredicate,K> { public K Kind => K.UnaryPredicate; }

        public readonly struct BinaryPredicate : IOperationClassHost<BinaryPredicate,K> { public K Kind => K.BinaryPredicate; }

        public readonly struct TernaryPredicate : IOperationClassHost<TernaryPredicate,K> { public K Kind => K.TernaryPredicate; }
    }
}