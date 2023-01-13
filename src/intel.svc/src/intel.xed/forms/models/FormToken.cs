//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XedForms
    {
        public readonly record struct FormToken : IComparable<FormToken>
        {
            readonly ByteBlock16 Data;

            [MethodImpl(Inline)]
            public FormToken(FormTokenKind kind, string value)
            {
                var data = ByteBlock16.Empty;
                @as<asci16>(data.First) = Asci.encode(value, out asci16 _);
                data[15] = (byte)kind;
                Data = data;
            }

            [MethodImpl(Inline)]
            public FormToken(AsmInstClass value)
            {
                var data = ByteBlock16.Empty;
                @as<AsmInstClass>(data.First) = value;
                data[15] = (byte)FormTokenKind.InstClass;
                Data = data;
            }

            [MethodImpl(Inline)]
            public FormToken(Hex8 value)
            {
                var data = ByteBlock16.Empty;
                @as<Hex8>(data.First) = value;
                data[15] = (byte)FormTokenKind.Hex8Lit;
                Data = data;
            }

            [MethodImpl(Inline)]
            public FormToken(Hex16 value)
            {
                var data = ByteBlock16.Empty;
                @as<Hex16>(data.First) = value;
                data[15] = (byte)FormTokenKind.Hex16Lit;
                Data = data;
            }

            public bool IsHexLit
            {
                [MethodImpl(Inline)]
                get => Kind == FormTokenKind.Hex16Lit || Kind == FormTokenKind.Hex8Lit;
            }

            public bool IsInstClass
            {
                [MethodImpl(Inline)]
                get => Kind == FormTokenKind.InstClass;
            }

            public NativeSize HexLitSize
            {
                [MethodImpl(Inline)]
                get => Kind == FormTokenKind.Hex16Lit ? NativeSizeCode.W16 : Kind == FormTokenKind.Hex8Lit ? NativeSizeCode.W8 : default;
            }

            public FormTokenKind Kind
            {
                [MethodImpl(Inline)]
                get => (FormTokenKind)Data[15];
            }

            [MethodImpl(Inline)]
            public ref readonly Hex8 Hex8Value()
                => ref @as<Hex8>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly Hex16 Hex16Value()
                => ref @as<Hex16>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly AsmInstClass InstClassValue()
                => ref @as<AsmInstClass>(Data.First);

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

            public asci16 Value
            {
                [MethodImpl(Inline)]
                get => ExtractName();
            }

            [MethodImpl(Inline)]
            asci16 ExtractName()
            {
                var src = Data;
                src[15] = 0;
                return @as<asci16>(src.First);
            }

            public string Format()
                => XedForms.format(this);

            public override string ToString()
                => Format();

            public int CompareTo(FormToken src)
                => XedForms.cmp(this,src);

            public static FormToken Empty => default;
        }
    }
}