//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class EcmaTables
    {
        public class TableAttribute : RecordAttribute
        {
            public TableAttribute(EcmaTableKind kind)
                : base($"Ecma.{kind}")
            {
                Kind = kind;
            }                

            public readonly EcmaTableKind Kind;
        }        
    }
}