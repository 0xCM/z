//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes a type that realizes both incrementing and decrementing operations
        /// </summary>
        /// <typeparam name="T">The target type</typeparam>
        public interface IStepwise<T> : IIncrementable<T>, IDecrementable<T>
            where T : unmanaged
        {

        }
    }
}