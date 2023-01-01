//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class JsonTypes 
    {
        public sealed record class Folder : JsonDataType<Folder>
        {
            public const string TypeName = "folder";

            public Folder()
                : base(TypeName)
            {

            }
        }
    }        
}