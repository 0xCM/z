//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedForms
    {
        public readonly record struct FormToken<T>
            where T : unmanaged
        {
            readonly ByteBlock16 Data;

            [MethodImpl(Inline)]
            public FormToken(ByteBlock16 data)
            {
                Data = data;
            }

            public T Value
            {
                [MethodImpl(Inline)]
                get => @as<T>(Data.First);
            }

            public FormTokenKind Kind
            {
                [MethodImpl(Inline)]
                get => (FormTokenKind)Data[15];
            }

            [MethodImpl(Inline)]
            public static implicit operator FormToken<T>(FormToken src)
                => new FormToken<T>(@as<FormToken,ByteBlock16>(src));
        }

        public readonly struct InstClassToken
        {
            readonly ByteBlock16 Data;

            [MethodImpl(Inline)]
            public InstClassToken(ByteBlock16 data)
            {
                Data = data;
            }
        }

        public readonly struct Hex8Token
        {
            readonly ByteBlock16 Data;

            [MethodImpl(Inline)]
            public Hex8Token(ByteBlock16 data)
            {
                Data = data;
            }
        }

        public readonly struct Hex16Token
        {
            readonly ByteBlock16 Data;

            [MethodImpl(Inline)]
            public Hex16Token(ByteBlock16 data)
            {
                Data = data;
            }
        }

        public readonly struct NamedToken
        {
            readonly ByteBlock16 Data;

            [MethodImpl(Inline)]
            public NamedToken(ByteBlock16 data)
            {
                Data = data;
            }
        }
    }
}