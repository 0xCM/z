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
            public const string TableId = "ecma.typedefs";

            public TypeAttributes Flags;

            public EcmaStringKey TypeName;

            public EcmaStringKey Namespace;

            public TypeLayout Layout;

            public EcmaRowKey Extends;

            public EcmaRowKey FieldList;

            public EcmaRowKey MethodList;
        }       
    }
}