//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public struct FieldDefs
        {
            internal readonly Index<FieldKind,FieldDef> Indexed;

            internal readonly Index<FieldDef> ByPos;

            [MethodImpl(Inline)]
            internal FieldDefs(Index<FieldKind,FieldDef> indexed, Index<FieldDef> positioned)
            {
                Indexed = indexed;;
                ByPos = positioned;
            }

            public void SortIndex()
            {
                Indexed.Storage.Sort();
            }
            public byte Count
            {
                [MethodImpl(Inline)]
                get => (byte)Indexed.Count;
            }

            public ref FieldDef this[FieldKind kind]
            {
                [MethodImpl(Inline)]
                get => ref Indexed[kind];
            }

            public ref FieldDef this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Indexed[(FieldKind)i];
            }

            public ref FieldDef this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Indexed[(FieldKind)i];
            }

            public ReadOnlySpan<FieldDef> Positioned
            {
                [MethodImpl(Inline)]
                get => slice(ByPos.View,1);
            }

            [MethodImpl(Inline)]
            public static implicit operator Index<FieldDef> (FieldDefs src)
                => src.Indexed.Storage;
        }
    }
}