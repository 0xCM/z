//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonTypes 
    {
        public sealed record class Path : JsonDataType<Path>
        {
            public const string TypeName = "path";

            public Path()
                : base(TypeName)
            {

            }
        }
    }        
}