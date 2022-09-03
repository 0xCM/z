//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes operations over (ordered) values that
        /// exist between upper and lower bounds
        /// </summary>
        /// <typeparam name="T">The operand type</typeparam>
        public interface IBoundReal<T> : IRealNumber<T>
            where T : unmanaged
        {

        }
    }
}