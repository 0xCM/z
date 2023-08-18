//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    [SymSource(xed), DataWidth(OpAttrib.KindWidth)]
    public enum OpAttribKind : byte
    {
        None,

        Action,

        Width,

        Visibility,

        Nonterminal,

        RegLiteral,

        Scale,

        ElementType,

        Modifier,
    }
}
