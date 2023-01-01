//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonTypes 
    {
        public sealed record class Time : JsonDataType<Time> 
        {
            public const string TypeName = "time";

            public Time()
                : base(TypeName)
            {

            }
        }
    }        
}