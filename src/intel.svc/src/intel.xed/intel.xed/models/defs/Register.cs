//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedModels
    {
        public readonly struct Register
        {
            public readonly XedRegId Value;

            [MethodImpl(Inline)]
            public Register(XedRegId src)
            {
                Value = src;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Value == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Value != 0;
            }

            public string Format()
                => Value == 0 ? EmptyString : XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Register(XedRegId src)
                => new Register(src);

            [MethodImpl(Inline)]
            public static implicit operator XedRegId(Register src)
                => src.Value;

            [MethodImpl(Inline)]
            public static explicit operator ushort(Register src)
                => (ushort)src.Value;

            [MethodImpl(Inline)]
            public static explicit operator Register(ushort src)
                => new Register((XedRegId)src);

           public static Register Empty => default;
        }
    }
}