//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonTypes 
    {
        public sealed record class U16 : JsonDataType<U16>
        {
            public const string TypeName = "u16";

            public U16()
                : base(TypeName)
            {

            }
        }
    }        
}