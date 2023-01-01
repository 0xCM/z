//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonTypes 
    {
        public sealed record class U64 : JsonDataType<U64>
        {
            public const string TypeName = "u64";

            public U64()
                : base(TypeName)
            {

            }
        }
    }        
}