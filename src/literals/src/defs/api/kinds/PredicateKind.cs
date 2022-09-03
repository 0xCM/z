//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using OC = OperationKind;

    [SymSource(api_kinds), Flags]
    public enum PredicateKind : ushort
    {
        /// <summary>
        /// The empty class
        /// </summary>
        None = 0,

        /// <summary>
        /// Classifies functions that return a system boolean value or a bit value
        /// </summary>
        Predicate = OC.Predicate,

        /// <summary>
        /// Classifies predicates that accept one argument
        /// </summary>
        UnaryPredicate = OC.UnaryPredicate,

        /// <summary>
        /// Classifies predicates that accept two arguments
        /// </summary>
        BinaryPredicate = OC.BinaryPredicate,

        /// <summary>
        /// Classifies predicates that accept three arguments
        /// </summary>
        TernaryPredicate = OC.TernaryPredicate,
    }
}