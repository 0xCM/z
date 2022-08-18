//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes operational inversion
        /// </summary>
        /// <typeparam name="T">The operand type</typeparam>
        public interface IInversionOps<T>
        {

        }

        /// <summary>
        /// Characterizes operational multiplicative inversion
        /// </summary>
        /// <typeparam name="T">The operand type</typeparam>
        public interface InversionMOps<T> : IInversionOps<T>
        {
            /// <summary>
            /// Multiplicative inversion
            /// </summary>
            /// <param name="x">The value to invert</param>
            T InvertM(T x);
        }

        /// <summary>
        /// Characterizes operational additive inversion
        /// </summary>
        /// <typeparam name="T">The operand type</typeparam>
        public interface InvertiveA<T> : IInversionOps<T>
        {
            /// <summary>
            /// Additive inversion
            /// </summary>
            /// <param name="x">The value to invert</param>
            T InvertA(T x);
        }
    }
}
