//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial struct Operational
    {
        /// <summary>
        /// Characterizes a sign adjudication operation
        /// </summary>
        /// <typeparam name="T">The operand type</typeparam>
        public interface ISignable<T>
        {
            /// <summary>
            /// Determines the sign of the supplied value
            /// </summary>
            PolarityKind Sign(T x);
        }
    }
}