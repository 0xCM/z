//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonTypes 
    {
        public sealed record class Records : JsonDataType<Records>
        {
            public const string TypeName = "array<record<${T}>>";

            public Records()
                : base(TypeName)
            {

            }
        }
    }        
}