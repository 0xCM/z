//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ICellDispenser<T> : IAllocDispenser<T>
        where T : unmanaged
    {

    }
}