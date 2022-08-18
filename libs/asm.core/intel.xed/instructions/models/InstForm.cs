//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [DataWidth(Width)]
        public struct InstForm : IEquatable<InstForm>, IComparable<InstForm>
        {
            public const byte Width = Hex14.Width;

            public readonly InstFormType Kind;

            [MethodImpl(Inline)]
            public InstForm(InstFormType src)
                => Kind = src;

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Kind != 0;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Kind == 0;
            }

            [MethodImpl(Inline)]
            public bool Equals(InstForm src)
                => ((ushort)Kind).Equals((ushort)src.Kind);

            [MethodImpl(Inline)]
            public int CompareTo(InstForm src)
                => ((ushort)Kind).CompareTo((ushort)src.Kind);


            public override int GetHashCode()
                =>(int)Kind;

            public override bool Equals(object src)
                => src is InstForm && Equals(src);

            public string Format()
                => Kind == 0 ? EmptyString :  Kind.ToString();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator InstForm(InstFormType src)
                => new InstForm(src);

            [MethodImpl(Inline)]
            public static implicit operator InstFormType(InstForm src)
                => src.Kind;

            [MethodImpl(Inline)]
            public static explicit operator ushort(InstForm src)
                => (ushort)src.Kind;

            [MethodImpl(Inline)]
            public static explicit operator InstForm(ushort src)
                => new InstForm((InstFormType)src);

            public static InstForm Empty => default;
        }
    }
}