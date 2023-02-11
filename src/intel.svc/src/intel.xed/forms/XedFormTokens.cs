//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedFormToken;
    
    public class XedFormTokens
    {
        public readonly Index<XedFormToken> TokenIndex;

        readonly Index<TokenKind,uint> Offsets;

        public readonly Index<TokenKind> Kinds;

        readonly ConstLookup<TokenKind, HashSet<string>> TokenNames;

        public XedFormTokens(Index<XedFormToken> index, Index<TokenKind,uint> offsets, Index<TokenKind> kinds, ConstLookup<TokenKind, HashSet<string>> names)
        {
            TokenIndex = index;
            Offsets = offsets;
            Kinds = kinds;
            TokenNames = names;
        }

        public HashSet<string> Names(TokenKind kind)
        {
            if(TokenNames.Find(kind, out var dst))
                return dst;
            else
                return hashset<string>();
        }

        public ReadOnlySpan<XedFormToken> Tokens(TokenKind kind)
        {
            var dst = default(ReadOnlySpan<XedFormToken>);
            if(kind != 0)
            {
                var i0 = Offsets[kind];
                if(kind != LastKind)
                {
                    var i1 = Offsets[kind++];
                    dst = segment(TokenIndex.View, i0,i1);
                }
                else
                    dst = slice(TokenIndex.View, i0);
            }
            return dst;
        }

        public TokenKind LastKind
        {
            [MethodImpl(Inline)]
            get => Kinds.Last;
        }
    }
}