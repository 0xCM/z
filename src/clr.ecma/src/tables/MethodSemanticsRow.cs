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
            [Render(12)]
            public EcmaToken Index;

            [Render(12)]
            public EcmaToken Method;

            [Render(12)]
            public EcmaToken Association;

            [Render(1)]
            public MethodSemanticsAttributes Semantics;
        }    
    }
}