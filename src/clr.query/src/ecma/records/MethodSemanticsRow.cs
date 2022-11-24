//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaRecordDefs
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct MethodSemanticsRow
        {
            const string TableId = "ecma.methods.semantics";

            public MethodSemanticsAttributes Semantic;

            public EcmaRowKey Method;

            public EcmaRowKey Association;
        }    

    }
}