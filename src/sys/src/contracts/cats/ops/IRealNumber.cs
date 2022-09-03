//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        public interface IRealNumber<T> : IOrderedNumber<T>, ITrigonmetric<T>
            where T : unmanaged

        {

        }
    }
}