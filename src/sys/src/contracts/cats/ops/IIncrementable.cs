//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        public interface IIncrementable<T>
            where T : unmanaged
        {
            T Inc(T x);
        }
    }
}