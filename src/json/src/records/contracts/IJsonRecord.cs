//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IJsonRecord
    {

    }

    public interface IJsonRecord<R> : IJsonRecord
        where R : IJsonRecord<R>, new()
    {

    }
}