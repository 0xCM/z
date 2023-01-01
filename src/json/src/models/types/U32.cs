//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonTypes 
    {
        public sealed record class U32 : JsonDataType<U32>
        {
            public const string TypeName = "u32";

            public U32()
                : base(TypeName)
            {

            }
        }
    }        
}