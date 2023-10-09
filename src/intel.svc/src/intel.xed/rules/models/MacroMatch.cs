//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    [Record(TableId)]
    public readonly record struct MacroMatch : IComparable<MacroMatch>
    {
        public const string TableId = "xed.rules.macros.matches";

        public const byte FieldCount = 5;

        public readonly uint Seq;

        public readonly RuleMacroKind Macro;

        public readonly FieldKind Field;

        public readonly string MatchValue;

        public readonly string Expansion;

        readonly uint Hash;

        [MethodImpl(Inline)]
        public MacroMatch(uint seq, RuleMacroKind macro, FieldKind field, MacroMatchKind match, string value, string expansion)
        {
            Seq = seq;
            Macro = macro;
            Field = field;
            MatchValue = value;
            Expansion = expansion;
            Hash = (uint)field | ((uint)macro << 8) | ((uint)match << 16);
        }

        [MethodImpl(Inline)]
        public MacroMatch WithSeq(uint seq)
            => new MacroMatch(seq,Macro,Field,0, MatchValue,Expansion);

        public override int GetHashCode()
            => (int)Hash;

        public int CompareTo(MacroMatch src)
            => XedRender.format(Macro).CompareTo(XedRender.format(src.Macro));

    }

    public enum MacroMatchKind : byte
    {
        Literal,

        Assign,
    }
}
