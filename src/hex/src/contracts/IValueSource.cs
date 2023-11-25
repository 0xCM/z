//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Free]
public interface IValueSource<T>

{
    T Next();


    ByteSize Fill(Span<T> dst);
}
