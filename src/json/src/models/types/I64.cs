//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonTypes 
    {
        public sealed record class I64 : JsonDataType<I64>
        {
            public const string TypeName = "i64";

            public I64()
                : base(TypeName)
            {

            }
        }
    }        
}