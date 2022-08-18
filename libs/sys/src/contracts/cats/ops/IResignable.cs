//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes a sign-reversal operation
        /// </summary>
        /// <typeparam name="T">The operand type</typeparam>
        public interface IResignable<T> : ISignable<T>, INegatable<T>
            where T : unmanaged
        {
            /// <summary>
            /// Aligns the value with a specified sign
            /// </summary>
            T Resign(T x, PolarityKind s);
        }
    }
}