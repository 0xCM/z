//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class JsonTypes 
    {
        public sealed record class Date : JsonDataType<Date> 
        {
            public const string TypeName = "date";

            public Date()
                : base(TypeName)
            {

            }
        }
    }        
}