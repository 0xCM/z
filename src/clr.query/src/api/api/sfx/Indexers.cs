//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public delegate T Indexer<E,T>(E k)
        where E : unmanaged
        where T : unmanaged;
}