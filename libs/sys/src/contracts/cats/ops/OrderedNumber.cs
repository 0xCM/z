//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes numeric operations in the presence of order
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public interface IOrderedNumber<T> : IStepwise<T>,  IOrdered<T>, INumber<T>
            where T : unmanaged
            { }
    }
}