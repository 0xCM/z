//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedForms
    {
        [MethodImpl(Inline)]
        public static HashSet<string> names(XedFormToken.TokenKind kind)
            => TokenData.Names(kind);
    }
}