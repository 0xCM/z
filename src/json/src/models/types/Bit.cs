//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonTypes 
    {
        public sealed record class Bit : JsonDataType<Bit>
        {
            public const string TypeName = "bit";

            public Bit()
                : base(TypeName)
            {

            }
        }
    }        
}