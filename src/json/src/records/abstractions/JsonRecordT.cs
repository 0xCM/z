//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonRecords
    {
        public abstract record class JsonRecord<R> : JsonRecord, IJsonRecord<R>
            where R : JsonRecord<R>, new()
        {
            
        }        
    }
}