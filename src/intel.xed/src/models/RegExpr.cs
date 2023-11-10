//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;

partial class XedModels
{
    public readonly struct RegExpr
    {        
        readonly XedRegId RegId;

        readonly RuleName Rule;

        [MethodImpl(Inline)]
        public RegExpr(XedRegId src)
        {
            RegId = src;
            Rule = 0;
        }

        [MethodImpl(Inline)]
        public RegExpr(RuleName src)
        {
            RegId = 0;
            Rule = src;
        }

        public bool IsNonterminal
        {
            [MethodImpl(Inline)]
            get => Rule != 0;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => RegId == 0 && Rule == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => RegId != 0 || Rule != 0;
        }

        public XedRegId AsRegister()
            => RegId;

        public RuleName AsRule()
            => Rule;

        public string Format()
        {
            var dst = EmptyString;
            if(IsNonterminal)
                dst = $"{XedRender.format(Rule)}()";
            else if(RegId != 0)
                dst = XedRender.format(RegId);
            return dst;
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator RegExpr(XedRegId src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator RegExpr(RuleName src)            
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator RegExpr(Nonterminal src)            
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator XedRegId(RegExpr src)
            => src.RegId;

        [MethodImpl(Inline)]
        public static explicit operator ushort(RegExpr src)
            => (ushort)src.RegId;

        [MethodImpl(Inline)]
        public static explicit operator RegExpr(ushort src)
            => new ((XedRegId)src);

        public static RegExpr Empty => default;
    }
}
