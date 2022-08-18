//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [AttributeUsage(AttributeTargets.Struct)]
    public class CliRecordAttribute : RecordAttribute
    {
        public CliRecordAttribute(CliTableKind kind)
            : base(kind.ToString())
        {
            TableKind = kind;
        }

        public CliTableKind TableKind {get;}
    }
}