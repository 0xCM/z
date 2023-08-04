//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Ecma
    {
        [EcmaRow(TableIndex.GenericParamConstraint), StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct GenericParamConstraintRow : IEcmaRow<GenericParamConstraintRow>
        {
            /// <summary>
            /// An index into the GenericParam table, specifying to which generic parameter this row refers
            /// </summary>
            [Render(12)]
            public EcmaToken Owner;

            /// <summary>
            /// An index into the TypeDef, TypeRef, or TypeSpec tables,
            /// specifying from which class this generic parameter is constrained to derive;
            /// or which interface this generic parameter is constrained to implement
            /// </summary>
            [Render(12)]
            public EcmaToken Constraint;
        }
    }
}