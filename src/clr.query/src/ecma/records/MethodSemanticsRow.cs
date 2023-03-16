//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaTables
    {
        [Table(TableIndex.MethodSemantics), StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct MethodSemanticsRow : IEcmaRecord<MethodSemanticsRow>
        {
            public MethodSemanticsAttributes Semantic;

            public EcmaRowKey Method;

            public EcmaRowKey Association;
        }    
    }
}