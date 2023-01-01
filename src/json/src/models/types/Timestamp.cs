//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonTypes 
    {
        public sealed record class Timestamp : JsonDataType<Timestamp>
        {
            public const string TypeName = "timestamp";

            public Timestamp()
                : base(TypeName)
            {

            }
        }
    }        
}