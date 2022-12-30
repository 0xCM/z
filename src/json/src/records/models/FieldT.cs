//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonRecords
    {
        public record class Field<T>
            where T : IJsonDataType, new()
        {
            public JsonText Name;

            public T Type;
        }
    }
}