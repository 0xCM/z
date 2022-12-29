//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonRecords
    {
        public abstract record class DataType : IDataType
        {
            public @string Name {get;}

            protected DataType(string name)
            {
                Name = name;
            }

        }        
    }
}