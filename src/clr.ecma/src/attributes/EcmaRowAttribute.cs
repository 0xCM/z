//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class EcmaRowAttribute : RecordAttribute
    {
        public EcmaRowAttribute(TableIndex kind)
            : base($"Ecma.{kind}")
        {
            Kind = kind;
        }                

        public readonly TableIndex Kind;
    }        
}