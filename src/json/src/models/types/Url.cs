//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonTypes 
    {
        public sealed record class Url : JsonDataType<Url>
        {
            public const string TypeName = "url";

            public Url()
                : base(TypeName)
            {

            }
        }
    }        
}