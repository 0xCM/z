//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class)]
    public class RecordGroupAttribute : Attribute
    {
        public string Docs {get;}

        public RecordGroupAttribute()
        {
            Docs = string.Empty;
        }

        public RecordGroupAttribute(string docs)
        {
            Docs = string.Empty;
        }
    }
}