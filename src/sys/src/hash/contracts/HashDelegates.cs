//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public delegate T HashFunction<T>(ReadOnlySpan<byte> src)
        where T : unmanaged;
}