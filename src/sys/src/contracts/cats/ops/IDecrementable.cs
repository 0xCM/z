//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        public interface IDecrementable<T>
            where T : unmanaged
        {
            T Dec(T x);
        }
    }
}