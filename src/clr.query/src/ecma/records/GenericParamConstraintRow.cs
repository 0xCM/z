//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaRecordDefs
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential,Pack =1)]
        public struct GenericParamConstraintRow
        {
            public const string TableId = "ecma.generic-param-constraint";

            /// <summary>
            /// An index into the GenericParam table, specifying to which generic parameter this row refers
            /// </summary>
            public EcmaRowKey Owner;

            /// <summary>
            /// An index into the TypeDef, TypeRef, or TypeSpec tables,
            /// specifying from which class this generic parameter is constrained to derive;
            /// or which interface this generic parameter is constrained to implement
            /// </summary>
            public EcmaRowKey Constraint;
        }
    }

}