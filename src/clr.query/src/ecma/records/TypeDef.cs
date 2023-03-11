//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaTables
    {
        [Table(TableIndex.TypeDef), StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TypeDef : IEcmaRecord<TypeDef>
        {
            public const string TableId = "ecma.typedefs";

            public TypeAttributes Flags;

            public EcmaStringIndex TypeName;

            public EcmaStringIndex Namespace;

            public TypeLayout Layout;

            public EcmaRowKey Extends;

            public EcmaRowKey FieldList;

            public EcmaRowKey MethodList;
        }       
    }
}