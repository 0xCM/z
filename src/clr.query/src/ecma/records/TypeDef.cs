//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaModels
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TypeDef
        {
            public const string TableId = "ecma.typedefs";

            public TypeAttributes Flags;

            public EcmaStringIndex TypeName;

            public EcmaStringIndex Namespace;

            public TypeLayout Layout;

            public EcmaRowIndex Extends;

            public EcmaRowIndex FieldList;

            public EcmaRowIndex MethodList;
        }       
    }
}