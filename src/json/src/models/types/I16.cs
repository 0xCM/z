//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonTypes 
    {
        public sealed record class I16 : JsonDataType<I16>
        {
            public const string TypeName = "i16";

            public I16()
                : base(TypeName)
            {

            }
        }
    }        
}