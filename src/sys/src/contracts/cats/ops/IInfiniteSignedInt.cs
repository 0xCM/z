//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial struct Operational
    {
        /// <summary>
        /// Characterizes operations over an unbound signed integral type
        /// </summary>
        /// <typeparam name="T">The operand type</typeparam>
        public interface IInfiniteSignedInt<T> : IInfiniteInt<T>, ISignedInt<T>
            where T : unmanaged
        {

        }
    }
}