//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes an operation provider for floating point values
        /// </summary>
        /// <typeparam name="T">The underlying numeric type</typeparam>
        public interface IFloating<T> :
            IRealNumber<T>,
            IFractional<T>,
            IResignable<T>,
            ISubtractive<T>,
            ITrigonmetric<T>
                where T : unmanaged
        {
            /// <summary>
            /// The minimal resolution of the data type
            /// </summary>
            T Epsilon {get;}

            /// <summary>
            /// Calculates the square root of the input
            /// </summary>
            /// <param name="x">The input value</param>
            T Sqrt(T x);
        }


        /// <summary>
        /// Characterizes an operation provider for bounded floating point values
        /// </summary>
        /// <typeparam name="T">The underlying numeric type</typeparam>
        public interface IFiniteFloat<T> : IFloating<T>, IBoundReal<T>
            where T : unmanaged

        { }


        /// <summary>
        /// Characterizes operational reifications of RealFiniteUInt
        /// </summary>
        /// <typeparam name="R">The reification type</typeparam>
        /// <typeparam name="T">The operand type</typeparam>
        public interface IFiniteFloat<R,T> : IFiniteFloat<T>
            where T : unmanaged
            where R : IFiniteFloat<R,T>, new() { }
    }
}