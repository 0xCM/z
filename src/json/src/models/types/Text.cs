//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonTypes 
    {
        public sealed record class Text : JsonDataType<Text>
        {
            public const string TypeName = "text";

            public Text()
                : base(TypeName)
            {

            }
        }
    }        
}