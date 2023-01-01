//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonTypes 
    {
        public sealed record class U8 : JsonDataType<U8>
        {
            public const string TypeName = "u8";

            public U8()
                : base(TypeName)
            {

            }
        }
    }        
}