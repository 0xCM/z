//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Identifies a structural type that be serialized as a record, of some sort
    /// </summary>
    [AttributeUsage(AttributeTargets.Struct)]
    public class RecordAttribute : Attribute
    {
        public string TableId {get;}

        public RecordAttribute(string name)
        {
            TableId = name;
        }
    }
}