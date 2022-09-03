//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        public interface IDivisive<T> : IModular<T>
            where T : unmanaged
        {
            T Div(T lhs, T rhs);

            T Gcd(T lhs, T rhs);

            (T q, T r) DivRem(T lhs, T rhs);
        }
    }
}