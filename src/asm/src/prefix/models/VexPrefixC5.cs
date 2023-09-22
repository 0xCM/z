//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static AsmPrefixTokens;
    using static sys;

    [DataWidth(16), ApiComplete]
    public record struct VexPrefixC5
    {
        [MethodImpl(Inline)]
        public static VexPrefixC5 init()
        {
            var dst = new VexPrefixC5();
            dst.B0 = (byte)VexPrefixCode.C5;
            return dst;
        }

        [MethodImpl(Inline)]
        public static VexPrefixC5 init(bit r = default, byte vvvv = default, VexLengthCode l = default, VexOpCodeExtension pp = default)
        {
            var dst = new VexPrefixC5();
            dst.B0 = (byte)VexPrefixCode.C5;
            dst.R = r;
            dst.VVVV = vvvv;
            dst.L = l;
            dst.PP = pp;
            return dst;
        }

        [MethodImpl(Inline)]
        public static VexPrefixC5 define(byte b1)
        {
            var dst = new VexPrefixC5();
            dst.B0 = (byte)VexPrefixCode.C5;
            dst.B1 = b1;
            return dst;
        }

        byte B0;

        byte B1;

        byte Unused1;

        byte Unused2;

        // ~ R

        const byte R_Mask = 0b1000_0000;

        const byte R_Min = 7;

        const byte R_Max = 7;

        const byte R_Width = R_Max - R_Min + 1;

        public bit R
        {
            [MethodImpl(Inline)]
            get => (bit)bits.extract(B1, R_Min, R_Max);

            [MethodImpl(Inline)]
            set => B1 = math.or(bits.scatter((byte)value, R_Mask), math.and(B1, math.not(R_Mask)));
        }

        public byte R_Bits
        {
            [MethodImpl(Inline)]
            get => (byte)R;
        }

        // ~ VVVV

        const byte VVVV_Mask = 0b0111_1000;

        const byte VVVV_Min = 3;

        const byte VVVV_Max = 6;

        const byte VVVV_Width = VVVV_Max - VVVV_Min + 1;

        public byte VVVV
        {
            [MethodImpl(Inline)]
            get => bits.extract(B1, VVVV_Min, VVVV_Max);

            [MethodImpl(Inline)]
            set => B1 = math.or(bits.scatter((byte)value, VVVV_Mask), math.and(B1, math.not(VVVV_Mask)));
        }

        public byte VVVV_Bits
        {
            [MethodImpl(Inline)]
            get => (byte)VVVV;
        }

        // ~ L

        const byte L_Mask = 0b0000_0100;

        const byte L_Min = 2;

        const byte L_Max = 2;

        const byte L_Width = L_Max - L_Min + 1;

        public VexLengthCode L
        {
            [MethodImpl(Inline)]
            get => (VexLengthCode)bits.extract(B1, L_Min, L_Max);

            [MethodImpl(Inline)]
            set => B1 = math.or(bits.scatter((byte)value, L_Mask), math.and(B1, math.not(L_Mask)));
        }

        public byte L_Bits
        {
            [MethodImpl(Inline)]
            get => (byte)L;
        }

        // ~ PP

        const byte PP_Mask = 0b0000_0011;

        const byte PP_Min = 0;

        const byte PP_Max = 1;

        const byte PP_Width = PP_Max - PP_Min + 1;

        public VexOpCodeExtension PP
        {
            [MethodImpl(Inline)]
            get => (VexOpCodeExtension)bits.extract(B1, PP_Min, PP_Max);

            [MethodImpl(Inline)]
            set => B1 =  math.or(bits.scatter((byte)value, PP_Mask), math.and(B1, math.not(PP_Mask)));
        }

        public byte PP_Bits
        {
            [MethodImpl(Inline)]
            get => (byte)PP;
        }

        public VexPrefixCode Code
        {
            [MethodImpl(Inline)]
            get => VexPrefixCode.C5;
        }

        public byte Size
        {
            [MethodImpl(Inline)]
           get => VexPrefix.size(Code);
        }

        public RegIndex Reg
        {
            [MethodImpl(Inline)]
            get => (RegIndex)math.not(VVVV);
        }

        public string Bitstring()
        {
            var storage = CharBlock32.Empty;
            var dst = storage.Data;
            var i=0u;
            BitRender.render8(B0, ref i, dst);
            seek(dst,i++) = Chars.Space;

            BitRender.render1(R_Bits, ref i, dst);
            seek(dst,i++) = Chars.Space;

            BitRender.render4(VVVV_Bits, ref i, dst);
            seek(dst,i++) = Chars.Space;

            BitRender.render1(L_Bits, ref i, dst);
            seek(dst,i++) = Chars.Space;

            BitRender.render2(PP_Bits, ref i, dst);

            return new string(slice(dst,0,i));
        }

        const string SemanticFormat = "{0}\n{1}\n{2}";

        public string FormatSemantic()
            => string.Format(SemanticFormat, Format(), AsmBitPatterns.VexC5, Bitstring());

        public string Format()
        {
            var b0 = B0.FormatHex(zpad:true, specifier:false, uppercase:false);
            var b1 = B1.FormatHex(zpad:true, specifier:false, uppercase:false);
            return string.Format("{0} {1}",b0,b1);
        }

        public override string ToString()
            => Format();
    }
}