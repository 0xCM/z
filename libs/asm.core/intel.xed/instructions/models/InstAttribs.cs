//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        public readonly struct InstAttribs : IIndex<InstAttribKind>
        {
            [MethodImpl(Inline)]
            public Bitset128<InstAttribKind> Bitset()
                => Bitsets.init(n128, Storage);

            readonly Index<InstAttribKind> Data;

            [MethodImpl(Inline)]
            public InstAttribs(InstAttribKind[] src)
            {
                Data = src;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Data.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Data.IsNonEmpty;
            }

            public InstAttribKind[] Storage
            {
                [MethodImpl(Inline)]
                get => Data;
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => Data.Count;
            }

            public ref InstAttribKind this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public ref InstAttribKind this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public bool Locked
            {
                [MethodImpl(Inline)]
                get => Data.Any(x => x == InstAttribKind.LOCKED);
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator InstAttribs(InstAttribKind[] src)
                => new InstAttribs(src);

            [MethodImpl(Inline)]
            public static implicit operator InstAttribKind[](InstAttribs src)
                => src.Data;

            [MethodImpl(Inline)]
            public static implicit operator Index<InstAttribKind>(InstAttribs src)
                => src.Data;

            public static InstAttribs Empty => sys.empty<InstAttribKind>();
        }
    }
}