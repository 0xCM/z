//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        public interface INatural<T> : IInteger<T>, INonNegative<T>
            where T : unmanaged
        {}
    }
}

