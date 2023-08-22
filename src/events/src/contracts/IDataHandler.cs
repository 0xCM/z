//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Free]
public interface IDataHandler
{
    void Handle(dynamic src);
}

[Free]
public interface IDataHandler<T> : IDataHandler
{
    void Handle(T src);

    void IDataHandler.Handle(dynamic src)
        => Handle(src);
}
