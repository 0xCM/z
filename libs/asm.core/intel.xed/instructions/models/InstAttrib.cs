//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly record struct InstAttrib : IComparable<InstAttrib>
        {
            public readonly InstAttribKind Kind;

            [MethodImpl(Inline)]
            public InstAttrib(InstAttribKind kind)
            {
                Kind = kind;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Kind == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Kind != 0;
            }

            public string Format()
                => IsNonEmpty ? Kind.ToString() : EmptyString;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public int CompareTo(InstAttrib src)
                => ((byte)Kind).CompareTo((byte)src.Kind);

            [MethodImpl(Inline)]
            public static implicit operator InstAttrib(InstAttribKind src)
                => new InstAttrib(src);

            [MethodImpl(Inline)]
            public static implicit operator InstAttribKind(InstAttrib src)
                => src.Kind;

            [MethodImpl(Inline)]
            public static explicit operator byte(InstAttrib src)
                => (byte)src.Kind;

            [MethodImpl(Inline)]
            public static explicit operator InstAttrib(byte src)
                => new InstAttrib((InstAttribKind)src);
        }
    }
}