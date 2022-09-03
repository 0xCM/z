//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IAllocDispenser : IDisposable
    {

    }

    [Free]
    public interface IAllocDispenser<T> : IAllocDispenser
    {

    }
}