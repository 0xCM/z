//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    [DataWidth(RuleKeyword.PackedWidth)]
    public enum KeywordKind : byte
    {
        [Symbol("")]
        None,

        [Symbol("@")]
        Wildcard,

        [Symbol("null")]
        Null,

        [Symbol("default")]
        Default,

        [Symbol("else")]
        Else,

        [Symbol("error")]
        Error,
    }
}
