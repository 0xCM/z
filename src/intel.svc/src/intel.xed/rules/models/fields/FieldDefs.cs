//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XedRules
    {
        public struct FieldDefs
        {
            internal readonly Index<FieldDef> Indexed;

            [MethodImpl(Inline)]
            internal FieldDefs(Index<FieldDef> indexed)
            {
                Indexed = indexed;
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
                get => ref Indexed[(uint)kind];
            }

            public ref FieldDef this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Indexed[i];
            }

            public ref FieldDef this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Indexed[i];
            }

            [MethodImpl(Inline)]
            public static implicit operator Index<FieldDef> (FieldDefs src)
                => src.Indexed.Storage;
        }
    }
}