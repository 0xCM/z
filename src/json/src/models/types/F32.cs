//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonTypes
    {
        public sealed record class F32 : JsonDataType<F32>
        {
            public const string TypeName = "f32";

            public F32()
                : base(TypeName)
            {

            }
        }
    }        
}