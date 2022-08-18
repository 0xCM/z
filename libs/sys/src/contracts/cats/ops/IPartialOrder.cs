//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes a partial order, i.e. a reflexive, transitive and antisymmetric binary operator
        /// </summary>
        /// <typeparam name="T">The relation domain</typeparam>
        /// <remarks>See https://en.wikipedia.org/wiki/Partially_ordered_set</remarks>
        public interface IPartialOrder<T> : IReflexive<T>, IAntisymmetric<T>, ITransitive<T>
            where T : unmanaged
        {

        }
    }
}