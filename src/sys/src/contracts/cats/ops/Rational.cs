//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes fractional operations
        /// </summary>
        /// <typeparam name="T">The operand type</typeparam>
        public interface IFractional<T> : IRealNumber<T>
            where T : unmanaged
        {
            T Ceil(T x);

            T Floor(T x);
        }
    }
}