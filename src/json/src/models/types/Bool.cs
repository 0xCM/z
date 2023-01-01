//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class JsonTypes 
    {
        public sealed record class Bool : JsonDataType<Bool>
        {
            public const string TypeName = "bool";

            public Bool()
                : base(TypeName)
            {

            }
        }
    }        
}