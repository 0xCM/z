//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaTables
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct MethodRelations
        {
            const string TableId = "ecma.methods.relations";

            [Render(12)]
            public EcmaToken Token;

            [Render(12)]
            public Address32 Rva;

            [Render(12)]
            public EcmaStringIndex NameKey;

            [Render(12)]
            public EcmaBlobIndex SigKey;

            [Render(12)]
            public EcmaRowKey FirstParam;

            [Render(12)]
            public ushort ParamCount;

            [Render(32)]
            public MethodImplAttributes ImplAttributes;

            [Render(1)]
            public MethodAttributes Attributes;
        }       
    }
}