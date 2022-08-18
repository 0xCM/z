//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    partial class TS
    {
        public readonly struct TypeKinds
        {
            public static TypeKind Literal => "literal";

            public static TypeKind String => "string";

            public static TypeKind Number = "number";

            public static TypeKind Union => "union";
        
            public static TypeKind StringLiteral => String < Literal;

            public static TypeKind NumericLiteral => Number < Literal;

            public static TypeKind StringLiteralUnion => Union + StringLiteral;

            public static TypeKind NumericLiteralUnion => Union + NumericLiteral;

            /// <summary>
            /// https://www.typescriptlang.org/docs/handbook/2/template-literal-types.html
            /// </summary>
            public static TypeKind TemplateLiteral => "template" < StringLiteral;
                   
        }
    }
}