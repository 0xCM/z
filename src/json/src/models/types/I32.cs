//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonTypes 
    {
        public sealed record class I32 : JsonDataType<I32>
        {
            public const string TypeName = "i32";

            public I32()
                : base(TypeName)
            {

            }
        }
    }        
}