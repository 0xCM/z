//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial struct Operational
    {
        /// <summary>
        /// Characterizes operations over a signed interal type
        /// </summary>
        /// <typeparam name="T">The operand type</typeparam>
        public interface ISignedInt<T> : IInteger<T>, ISignable<T>, ISubtractive<T>
            where T : unmanaged
        {

        }
    }
}