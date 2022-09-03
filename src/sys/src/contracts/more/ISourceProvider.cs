//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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