//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaTables
    {
        [EcmaRow(TableIndex.TypeDef), StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TypeDefRow : IEcmaRow<TypeDefRow>
        {
            [Render(1)]
            public EcmaToken Index;

            [Render(12)]
            public EcmaStringKey TypeName;

            [Render(12)]
            public EcmaStringKey Namespace;

            [Render(16)]
            public TypeLayout Layout;

            [Render(12)]
            public EcmaToken BaseType;

            [Render(12)]
            public EcmaToken FieldList;

            [Render(12)]
            public EcmaToken MethodList;
 
            [Render(1)]
            public TypeAttributes Attributes;
        }       
    }
}