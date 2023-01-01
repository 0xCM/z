//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class JsonTypes 
    {
        public sealed record class I8 : JsonDataType<I8>
        {
            public const string TypeName = "i8";

            public I8()
                : base(TypeName)
            {

            }
        }
    }        
}