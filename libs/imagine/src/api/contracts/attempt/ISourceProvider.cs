//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ISourceProvider
    {
        ISource Source(string name, string type)
            => throw new NotImplementedException();
    }

    [Free]
    public interface ISourceProvider<T> : ISourceProvider
        where T : ISource
    {
        T Source();
    }
}