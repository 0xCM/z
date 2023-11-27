//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Free]
public interface IMemoryStream
{
    uint Terms(MemoryAddress @base, uint count, dynamic min, dynamic max);    
}

[Free]
public interface IMemoryStream<T> : IMemoryStream
    where T : unmanaged
{
    uint Terms(MemoryAddress @base, uint count, T min, T max);

    uint IMemoryStream.Terms(MemoryAddress @base, uint count, dynamic min, dynamic max)
        => Terms(@base, count, (T)min, (T)max);
}
