//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly record struct XedFormToken : IComparable<XedFormToken>
    {
        public enum TokenKind : byte
        {
            None,

            RegClass,

            RegIndex,

            OpClass,

            AddressClass,

            Cpuid,

            Field,

            NonTerm,

            IsaKind,

            InstCategory,

            Gp8RegLit,

            Gp16RegLit,

            Gp32RegLit,

            Gp64RegLit,

            CrRegLit,

            DbRegLit,

            SegRegLit,

            Rep,

            InstClass,

            Hex8Lit,

            Hex16Lit
        }        

        readonly ByteBlock16 Data;

        [MethodImpl(Inline)]
        public XedFormToken(TokenKind kind, string value)
        {
            var data = ByteBlock16.Empty;
            @as<asci16>(data.First) = Asci.encode(value, out asci16 _);
            data[15] = (byte)kind;
            Data = data;
        }

        [MethodImpl(Inline)]
        public XedFormToken(XedInstClass value)
        {
            var data = ByteBlock16.Empty;
            @as<XedInstClass>(data.First) = value;
            data[15] = (byte)TokenKind.InstClass;
            Data = data;
        }

        [MethodImpl(Inline)]
        public XedFormToken(Hex8 value)
        {
            var data = ByteBlock16.Empty;
            @as<Hex8>(data.First) = value;
            data[15] = (byte)TokenKind.Hex8Lit;
            Data = data;
        }

        [MethodImpl(Inline)]
        public XedFormToken(Hex16 value)
        {
            var data = ByteBlock16.Empty;
            @as<Hex16>(data.First) = value;
            data[15] = (byte)TokenKind.Hex16Lit;
            Data = data;
        }

        public bool IsHexLit
        {
            [MethodImpl(Inline)]
            get => Kind == TokenKind.Hex16Lit || Kind == TokenKind.Hex8Lit;
        }

        public bool IsInstClass
        {
            [MethodImpl(Inline)]
            get => Kind == TokenKind.InstClass;
        }

        public NativeSize HexLitSize
        {
            [MethodImpl(Inline)]
            get => Kind == TokenKind.Hex16Lit ? NativeSizeCode.W16 : Kind == TokenKind.Hex8Lit ? NativeSizeCode.W8 : default;
        }

        public TokenKind Kind
        {
            [MethodImpl(Inline)]
            get => (TokenKind)Data[15];
        }

        [MethodImpl(Inline)]
        public ref readonly Hex8 Hex8Value()
            => ref @as<Hex8>(Data.First);

        [MethodImpl(Inline)]
        public ref readonly Hex16 Hex16Value()
            => ref @as<Hex16>(Data.First);

        [MethodImpl(Inline)]
        public ref readonly XedInstClass InstClassValue()
            => ref @as<XedInstClass>(Data.First);

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

        public int CompareTo(XedFormToken src)
            => XedForms.cmp(this,src);

        public static XedFormToken Empty => default;
    }
}