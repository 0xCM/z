//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial struct Operational
    {
        /// <summary>
        /// Characterizes operations over a signed, finite interal type
        /// </summary>
        /// <typeparam name="T">The operand type</typeparam>
        public interface IFiniteSignedInt<T> : ISignedInt<T>, IBoundReal<T>
            where T : unmanaged
        {

        }
    }
}