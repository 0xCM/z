//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    [StructLayout(LayoutKind.Sequential, Size=2, Pack=1)]
    public readonly record struct AsmOcToken : IToken<AsmOcToken,AsmOcTokenKind,byte>
    {
        public readonly AsmOcTokenKind Kind;

        public readonly byte Value;

        [MethodImpl(Inline)]
        public AsmOcToken(AsmOcTokenKind kind, byte value)
        {
            Value = value;
            Kind = kind;
        }

        public uint Id
        {
            [MethodImpl(Inline)]
            get => bits.join((byte)Value, (byte)Kind);
        }

        [MethodImpl(Inline)]
        public int CompareTo(AsmOcToken src)
        {
            var result = ((byte)Kind).CompareTo((byte)src.Kind);
            if(result == 0)
                result = Value.CompareTo(src.Value);
            return result;
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

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => core.bw16(this);
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(AsmOcToken src)
            => Kind == src.Kind && Value == src.Value;

        public string Format()
            => SdmOpCodes.format(this);

        public override string ToString()
            => Format();

        AsmOcTokenKind IToken<AsmOcTokenKind,byte>.Kind
            => Kind;

        byte IToken<byte>.Value
            => Value;

        [MethodImpl(Inline)]
        public static explicit operator byte(AsmOcToken src)
            => src.Value;

       public static AsmOcToken Empty => default;
    }
}