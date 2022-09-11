//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class DevSlnSchema : Schema<DevSlnSchema>
    {
        public Identifier SlnId;

        public FilePath SlnRoot;

        public DevSlnSchema()
        {
            SlnId = EmptyString;
            SlnRoot = FilePath.Empty;
        }

        public DevSlnSchema(string sln, FilePath root)
        {
            SlnId = sln;
            SlnRoot = root;
        }        
    }
}