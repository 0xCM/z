//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Binary
{
    public interface IDataSource
    {
        ReadOnlySpan<byte> Data {get;}
    }   
}