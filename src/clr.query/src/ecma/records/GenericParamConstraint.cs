//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaModels
    {
        [Table(EcmaTableKind.GenericParamConstraint), StructLayout(LayoutKind.Sequential,Pack =1)]
        public struct GenericParamConstraint : IEcmaRecord<GenericParamConstraint>
        {
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