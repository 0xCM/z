//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        public interface IAbsolutive<T>
            where T : unmanaged
        {
            T Abs(T x);
        }
    }
}