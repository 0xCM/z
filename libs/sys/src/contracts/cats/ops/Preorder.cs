//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes a preorder, i.e. a reflexive and transitive
        /// binary relation over its domain
        /// </summary>
        /// <typeparam name="T">The preorder domain</typeparam>
        /// <remarks>See https://en.wikipedia.org/wiki/Preorder </remarks>
        public interface IPreorder<T> : IReflexive<T>, ITransitive<T>
        {

        }

        /// <summary>
        /// Characterizes a set equipped with a preorder
        /// </summary>
        /// <typeparam name="T">The element type</typeparam>
        /// <remarks>See https://en.wikipedia.org/wiki/Preorder </remarks>
        public interface IProset<T> : IPreorder<T>

        {

        }
    }
}