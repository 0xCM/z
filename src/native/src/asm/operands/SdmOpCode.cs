//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using Asm;

    public struct SdmOpCode : IEquatable<SdmOpCode>
    {
        public const byte TokenCapacity = 31;

        Cell512 Data;

        [MethodImpl(Inline)]
        public SdmOpCode(Cell512 data)
        {
            Data = data;
        }

        [MethodImpl(Inline)]
        public SdmOpCode(ReadOnlySpan<AsmOcToken> tokens)
        {
            Data = first(recover<AsmOcToken,Cell512>(tokens));
            var _tokens = Buffer();
            var counter = z8;
            for(var i=0; i<TokenCapacity; i++)
            {
                if(skip(_tokens,i).Id != 0)
                    counter++;
                else
                    break;
            }

            TokenCount = counter;
        }

        [MethodImpl(Inline)]
        Span<AsmOcToken> Buffer()
            => recover<AsmOcToken>(Data.Bytes);

        ref ushort Settings
        {
            [MethodImpl(Inline)]
            get => ref seek(recover<ushort>(Data.Bytes), TokenCapacity-1);
        }

        public ReadOnlySpan<AsmOcToken> Tokens()
            => Buffer();

        public Span<AsmOcToken> Tokens(AsmOcTokenKind kind)
            => Tokens().Where(t => t.Kind == kind);

        public AsmOcValue OcValue()
        {
            var hex = Tokens(AsmOcTokenKind.Hex8);
            var count = hex.Length;
            var dst = AsmOcValue.Empty;
            switch(count)
            {
                case 1:
                    dst = new AsmOcValue((byte)skip(hex, 0));
                break;
                case 2:
                    dst = new AsmOcValue((byte)skip(hex, 0), (byte)skip(hex, 1));
                break;
                case 3:
                    dst = new AsmOcValue((byte)skip(hex, 0), (byte)skip(hex, 1), (byte)skip(hex, 2));
                break;
                case 4:
                    dst = new AsmOcValue((byte)skip(hex, 0), (byte)skip(hex, 1), (byte)skip(hex, 2), (byte)skip(hex, 3));
                break;
            }
            return dst;
        }

        public ref byte TokenCount
        {
            [MethodImpl(Inline)]
            get => ref @as<byte>(Settings);
        }

        public ref AsmOcToken this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref seek(Buffer(), i);
        }

        public ref AsmOcToken this[int i]
        {
            [MethodImpl(Inline)]
            get => ref seek(Buffer(), i);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => TokenCount == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => TokenCount != 0;
        }

        public AsmOcFlags Flags()
        {
            var count = TokenCount;
            var flags = AsmOcFlags.None;
            for(var i=0; i<count; i++)
                flags |= (AsmOcFlags)Pow2.pow((byte)this[i].Kind);
            return flags;
        }

        public Hex32 Hash
            => Data.GetHashCode();

        [MethodImpl(Inline)]
        public bool Equals(SdmOpCode src)
            => Data.Equals(src.Data);

        public override bool Equals(object src)
            => src is SdmOpCode x && Equals(x);

        public override int GetHashCode()
            => (int)Hash;

        public string Format()
            => SdmOpCodes.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static bool operator ==(SdmOpCode a, SdmOpCode b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(SdmOpCode a, SdmOpCode b)
            => !a.Equals(b);

        public static SdmOpCode Empty => new SdmOpCode(sys.empty<AsmOcToken>());
    }
}