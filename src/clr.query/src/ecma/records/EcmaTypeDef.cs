//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack =1)]
    public struct EcmaTypeDef : IEcmaRecord<EcmaTypeDef>
    {
        public const string TableId = "ecma.typedefs";

        public TypeAttributes Attributes;

        public EcmaStringIndex Name;

        public EcmaStringIndex Namespace;

        public TypeLayout Layout;

        public int Extends;

        public int FieldList;

        public int MethodList;
    }
}