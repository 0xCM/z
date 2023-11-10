//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct MacroSpec : IComparable<MacroSpec>
    {
        public readonly RuleMacroKind Name;

        public readonly FieldKind Field;

        public Index<MacroExpansion> Expansions;

        [MethodImpl(Inline)]
        public MacroSpec(RuleMacroKind name, FieldKind field, params MacroExpansion[] expansions)
        {
            Name = name;
            Field = field;
            Expansions = expansions;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name != 0;
        }

        public string Format()
            => XedRender.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(MacroSpec src)
            => ((uint)Name).CompareTo((uint)src.Name);

        public static MacroSpec Empty => new MacroSpec(RuleMacroKind.nothing, 0,sys.empty<MacroExpansion>());
    }
}
