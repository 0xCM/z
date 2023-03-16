//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaTables
    {
        [EcmaRow(TableIndex.MethodSemantics), StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct MethodSemanticsRow : IEcmaRow<MethodSemanticsRow>
        {
            public MethodSemanticsAttributes Semantic;

            public EcmaRowKey Method;

            public EcmaRowKey Association;
        }    
    }
}