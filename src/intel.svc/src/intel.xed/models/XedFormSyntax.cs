//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct XedFormSyntax
    {
        readonly ReadOnlySeq<XedFormToken> Tokens;

        [MethodImpl(Inline)]
        public XedFormSyntax(XedFormToken[] src)
        {
            Tokens = src;
        }

        public static XedFormSyntax Empty => new XedFormSyntax(sys.empty<XedFormToken>());
    }   
}