//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class JsonRecord<R> : JsonRecord, IJsonRecord<R>
        where R : JsonRecord<R>, new()
    {
        
    }   
}