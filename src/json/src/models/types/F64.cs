//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonTypes 
    {
        public sealed record class F64 : JsonDataType<F64>
        {
            public const string TypeName = "f64";

            public F64()
                : base(TypeName)
            {

            }
        }
    }        
}