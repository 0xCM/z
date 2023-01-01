//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonTypes 
    {
        public sealed record class Array : JsonDataType<Array> 
        {
            public const string TypeName = "array<${T}>";

            public Array()
                : base(TypeName)
            {

            }
        }
    }        
}