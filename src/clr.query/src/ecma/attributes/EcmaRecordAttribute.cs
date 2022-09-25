//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [AttributeUsage(AttributeTargets.Struct)]
    public class EcmaRecordAttribute : RecordAttribute
    {
        public EcmaRecordAttribute(EcmaTableKind kind)
            : base(kind.ToString())
        {
            TableKind = kind;
        }

        public EcmaTableKind TableKind {get;}
    }
}