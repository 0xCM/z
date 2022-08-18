//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes an operation provider for bounded natural types
        /// </summary>
        /// <typeparam name="T">The type over which operations are defined</typeparam>
        public interface IFiniteNatural<T> : INatural<T>, IBoundReal<T>
            where T : unmanaged
        { }

        /// <summary>
        /// Characterizes operational reifications of RealFiniteUInt
        /// </summary>
        /// <typeparam name="R">The reification type</typeparam>
        /// <typeparam name="T">The operand type</typeparam>
        public interface IFiniteNatural<R,T> : IFiniteNatural<T>
            where R : IFiniteNatural<R,T>, new()
            where T : unmanaged
            {

            }
    }
}

