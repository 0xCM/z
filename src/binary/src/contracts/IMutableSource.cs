//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Binary
{
    public interface IMutableSource : IDataSource
    {
        new Span<byte> Data {get;}

        ReadOnlySpan<byte> IDataSource.Data
            => Data;            
    }
}