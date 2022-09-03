//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        ///  Characterizes a reflexive, symmetric and transitive binary relation over a set
        /// \that, consequently, effects a partition over the set
        /// </summary>
        /// <typeparam name="T">The element type</typeparam>
        /// <remarks>See https://en.wikipedia.org/wiki/Equivalence_relation</remarks>
        public interface IEquivalence<T> : IReflexive<T>, ISymmetric<T>, ITransitive<T>
        {

        }
    }
}