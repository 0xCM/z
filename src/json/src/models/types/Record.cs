//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonTypes 
    {
        public sealed record class Record : JsonDataType<Record>
        {
            public const string TypeName = "record<${T}>";

            public Record()
                : base(TypeName)
            {

            }
        }
    }        
}