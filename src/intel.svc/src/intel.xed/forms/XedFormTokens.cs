//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedForms;
    
    public class XedFormTokens
    {
        public readonly Index<FormToken> TokenIndex;

        readonly Index<FormTokenKind,uint> Offsets;

        public readonly Index<FormTokenKind> Kinds;

        readonly ConstLookup<FormTokenKind, HashSet<string>> TokenNames;

        public XedFormTokens(Index<FormToken> index, Index<FormTokenKind,uint> offsets, Index<FormTokenKind> kinds, ConstLookup<FormTokenKind, HashSet<string>> names)
        {
            TokenIndex = index;
            Offsets = offsets;
            Kinds = kinds;
            TokenNames = names;
        }

        public HashSet<string> Names(FormTokenKind kind)
        {
            if(TokenNames.Find(kind, out var dst))
                return dst;
            else
                return hashset<string>();
        }

        public ReadOnlySpan<FormToken> Tokens(FormTokenKind kind)
        {
            var dst = default(ReadOnlySpan<FormToken>);
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

        public FormTokenKind LastKind
        {
            [MethodImpl(Inline)]
            get => Kinds.Last;
        }
    }
}