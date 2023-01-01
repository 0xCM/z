//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class JsonTypes 
    {
        public sealed record class Bits : JsonDataType<Bits>
        {
            public const string TypeName = "bits<${n}>";

            public Bits()
                : base(TypeName)
            {

            }
        }
    }        
}