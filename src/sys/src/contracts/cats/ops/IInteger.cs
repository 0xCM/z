//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial struct Operational
    {
        /// <summary>
        /// Characterizes operations over an integer type
        /// </summary>
        /// <typeparam name="T">The operand type</typeparam>
        public interface IInteger<T> : IRealNumber<T>, IStepwise<T>, IBitwise<T>
            where T : unmanaged
        {

        }
    }
}