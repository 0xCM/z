//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaTables
    {
        [EcmaRow(TableIndex.MethodDef), StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct MethodDefRow : IEcmaRow<MethodDefRow>
        {
            [Render(12)]
            public EcmaToken Index;

            [Render(12)]
            public EcmaToken DeclaringType;

            [Render(12)]
            public Address32 Rva;

            [Render(12)]
            public EcmaStringKey NameKey;

            [Render(12)]
            public EcmaBlobKey SigKey;

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