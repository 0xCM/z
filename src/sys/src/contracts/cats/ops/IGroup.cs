//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes group operations over a type
        /// </summary>
        /// <typeparam name="T">The operand type</typeparam>
        public interface IGroup<T> : IInversionOps<T>, ISemigroup<T>
        {

        }
    }
}