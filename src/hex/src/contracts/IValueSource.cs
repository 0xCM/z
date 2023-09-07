//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public interface IValueSource
{
    dynamic Next();
}

[Free]
public interface IValueSource<T>
{
    T Next();
}
