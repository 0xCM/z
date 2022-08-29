//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [AttributeUsage(AttributeTargets.Struct)]
    public class DbRecordAttribute : RecordAttribute
    {
        public string Schema {get;}

        public DbRecordAttribute(string schema, string id)
            : base(id)
        {
            Schema = schema;
        }
    }
}