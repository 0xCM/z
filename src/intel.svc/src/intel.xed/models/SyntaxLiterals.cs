//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    [LiteralProvider]
    internal readonly struct SyntaxLiterals
    {
        public const string SeqDeclSyntax = "SEQUENCE";

        public const string TableDeclSyntax = "()::";

        public const string CallSyntax = "()";

        public const string EncStep = "->";

        public const string DecStep = "|";
    }
}
