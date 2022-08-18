//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        public interface ILeftDistributive<T>  : IMultiplicative<T>, IAdditive<T>
            where T : unmanaged
        {
            /// <summary>
            /// Characterizes a type that defines an operator that left-distributes
            /// multiplication over addition
            /// </summary>
            /// <typeparam name="X">The operand type</typeparam>
            T Distribute(T lhs, (T x, T y) rhs);
        }
    }
}