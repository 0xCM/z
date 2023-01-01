//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class JsonTypes 
    {
        public sealed record class File : JsonDataType<File>
        {
            public const string TypeName = "file";

            public File()
                : base(TypeName)
            {

            }
        }
    }        
}