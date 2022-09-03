//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        public interface IMultiplicativeGroup<T> : IGroup<T>, IMultiplicativeMonoid<T>, InversionMOps<T>
        {

        }
    }
}