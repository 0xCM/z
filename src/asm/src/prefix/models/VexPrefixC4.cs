//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static AsmPrefixTokens;
    using static sys;

    [DataWidth(24), ApiComplete]
    public record struct VexPrefixC4
    {
        // ~ RXB
        const byte RXB_Mask = 0b1110_0000;

        const byte RXB_Min = 5;

        const byte RXB_Max = 7;

        const byte RXB_Width = RXB_Max - RXB_Min + 1;

        public static Segments segments()
            => new ();

        public class Segments
        {
            public CodeSeg Code {get;} = new();

            public RxbSeg RXB {get;} = new();

            public MSeg MMMMM {get;} = new();

            public WSeg W {get;} = new();

            public VVVVSeg VVVV {get;} = new();

            public LSeg L {get;} = new();

            public PPSeg PP {get;} = new();

            public string ToBitstring()
            {
                var storage = CharBlock32.Empty;
                var dst = storage.Data;
                var i=0u;
                i += Code.Render(dst);
                seek(dst,i++) = Chars.Space;

                i += RXB.Render(i,dst);
                seek(dst,i++) = Chars.Space;

                i += MMMMM.Render(i,dst);
                seek(dst,i++) = Chars.Space;

                i += W.Render(i,dst);
                seek(dst,i++) = Chars.Space;

                i += VVVV.Render(i,dst);
                seek(dst,i++) = Chars.Space;

                i += L.Render(i,dst);
                seek(dst,i++) = Chars.Space;

                i += PP.Render(i,dst);

                return new string(slice(dst,0,i));
            }

            public void Fill(in VexPrefixC4 src)
            {
                RXB.Value = src.RXB;
                MMMMM.Value = src.MMMMM;
                W.Value = src.W;
                VVVV.Value = src.VVVV;
                L.Value = src.L;
                PP.Value = src.PP;
            }
        }

        public sealed class CodeSeg : BitfieldSeg<byte,VexPrefixCode>
        {
            public CodeSeg()
                : base(0xFF,(0,7))
            {
                Value = VexPrefixCode.C4;
            }
        }

        public sealed class RxbSeg : BitfieldSeg<byte,VexRXB>
        {
            public RxbSeg()
                : base(RXB_Mask,(RXB_Min,RXB_Max))
            {

            }
        }

        public sealed class MSeg : BitfieldSeg<byte,VexM>
        {
            public MSeg()
                : base(MMMMM_Mask,(MMMMM_Min,MMMMM_Max))
            {

            }
        }

        public sealed class WSeg : BitfieldSeg<byte,bit>
        {
            public WSeg()
                : base(W_Mask, (W_Min,W_Max))
            {

            }
        }

        public sealed class VVVVSeg : BitfieldSeg<byte,byte>
        {
            public VVVVSeg()
                : base(VVVV_Mask, (VVVV_Min,VVVV_Max))
            {

            }
        }

        public sealed class LSeg : BitfieldSeg<byte,VexLengthCode>
        {
            public LSeg()
                : base(L_Mask,(L_Min,L_Max))
            {

            }
        }

        public sealed class PPSeg : BitfieldSeg<byte,VexOpCodeExtension>
        {
            public PPSeg()
                : base(PP_Mask,(PP_Min, PP_Max))
            {

            }
        }

        [MethodImpl(Inline)]
        public static VexPrefixC4 init()
        {
            var dst = new VexPrefixC4();
            dst.B0 = (byte)VexPrefixCode.C4;
            return dst;
        }

        [MethodImpl(Inline)]
        public static VexPrefixC4 init(VexRXB rxb, VexM mmmmm = default, bit w = default, byte vvvv = default, VexLengthCode l = default, VexOpCodeExtension pp = default)
        {
            var dst = new VexPrefixC4();
            dst.B0 = (byte)VexPrefixCode.C4;
            dst.RXB = rxb;
            dst.MMMMM = mmmmm;
            dst.W = w;
            dst.VVVV = vvvv;
            dst.L = l;
            dst.PP = pp;
            return dst;
        }

        [MethodImpl(Inline)]
        public static VexPrefixC4 define(byte b1, byte b2)
        {
            var dst = new VexPrefixC4();
            dst.B0 = (byte)VexPrefixCode.C4;
            dst.B1 = b1;
            dst.B2 = b2;
            return dst;
        }

        byte B0;

        byte B1;

        byte B2;

        byte Unused;

        public VexRXB RXB
        {
            [MethodImpl(Inline)]
            get => (VexRXB)bits.extract(B1, RXB_Min, RXB_Max);

            [MethodImpl(Inline)]
            set => B1 = math.or(bits.scatter((byte)value, RXB_Mask), math.and(B1, math.not(RXB_Mask)));
        }

        internal byte RXB_Bits
        {
            [MethodImpl(Inline)]
            get => (byte)RXB;
        }

        // ~ M
        const byte MMMMM_Mask = 0b0001_1111;

        const byte MMMMM_Min = 0;

        const byte MMMMM_Max = 4;

        const byte MMMMM_Width = MMMMM_Max - MMMMM_Min + 1;

        public VexM MMMMM
        {
            [MethodImpl(Inline)]
            get => (VexM)bits.extract(B1, MMMMM_Min, MMMMM_Max);

            [MethodImpl(Inline)]
            set => B1 = math.or(bits.scatter((byte)value, MMMMM_Mask), math.and(B1, math.not(MMMMM_Mask)));
        }

        internal byte MMMMM_Bits
        {
            [MethodImpl(Inline)]
            get => (byte)MMMMM;
        }

        // ~ W

        const byte W_Mask = 0b1000_0000;

        const byte W_Min = 7;

        const byte W_Max = 7;

        const byte W_Width = W_Max - W_Min + 1;

        public bit W
        {
            [MethodImpl(Inline)]
            get => (bit)bits.extract(B2, W_Min, W_Max);

            [MethodImpl(Inline)]
            set => B2 = math.or(bits.scatter((byte)value, W_Mask), math.and(B2, math.not(W_Mask)));
        }

        public byte W_Bits
        {
            [MethodImpl(Inline)]
            get => (byte)W;
        }

        // ~ VVVV

        const byte VVVV_Mask = 0b0111_1000;

        const byte VVVV_Min = 3;

        const byte VVVV_Max = 6;

        const byte VVVV_Width = VVVV_Max - VVVV_Min + 1;

        public byte VVVV
        {
            [MethodImpl(Inline)]
            get => bits.extract(B2, VVVV_Min, VVVV_Max);

            [MethodImpl(Inline)]
            set => B2 = math.or(bits.scatter((byte)value, VVVV_Mask), math.and(B2, math.not(VVVV_Mask)));
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
            get => (VexLengthCode)bits.extract(B2, L_Min, L_Max);

            [MethodImpl(Inline)]
            set => B2 = math.or(bits.scatter((byte)value, L_Mask), math.and(B2, math.not(L_Mask)));
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
            get => (VexOpCodeExtension)bits.extract(B2, PP_Min, PP_Max);

            [MethodImpl(Inline)]
            set => B2 =  math.or(bits.scatter((byte)value, PP_Mask), math.and(B2, math.not(PP_Mask)));
        }

        public byte PP_Bits
        {
            [MethodImpl(Inline)]
            get => (byte)PP;
        }

        const string SemanticFormat = "{0}\n{1}\n{2}";

        public VexPrefixCode PrefixCode
        {
            [MethodImpl(Inline)]
            get => VexPrefixCode.C4;
        }

        public RegIndex Reg
        {
            [MethodImpl(Inline)]
            get => (RegIndex)math.not(VVVV);
        }

        public byte Size
        {
            [MethodImpl(Inline)]
           get => VexPrefix.size(PrefixCode);
        }

        public string Bitstring()
        {
            var storage = CharBlock64.Empty;
            var dst = storage.Data;
            var i=0u;
            BitRender.render8(B0, ref i, dst);
            seek(dst,i++) = Chars.Space;

            BitRender.render3(RXB_Bits, ref i, dst);
            seek(dst,i++) = Chars.Space;

            BitRender.render5(MMMMM_Bits, ref i, dst);
            seek(dst,i++) = Chars.Space;

            BitRender.render1(W_Bits, ref i, dst);
            seek(dst,i++) = Chars.Space;

            BitRender.render4(VVVV_Bits, ref i, dst);
            seek(dst,i++) = Chars.Space;

            BitRender.render1(L_Bits, ref i, dst);
            seek(dst,i++) = Chars.Space;

            BitRender.render2(PP_Bits, ref i, dst);

            var content = slice(dst,0,i);
            return new string(content);
        }

        public string FormatSemantic()
            => string.Format(SemanticFormat, Format(), AsmBitPatterns.VexC4, Bitstring());

        public string Format()
        {
            var b0 = B0.FormatHex(zpad:true, specifier:false, uppercase:false);
            var b1 = B1.FormatHex(zpad:true, specifier:false, uppercase:false);
            var b2 = B2.FormatHex(zpad:true, specifier:false, uppercase:false);
            return string.Format("{0} {1} {2}",b0,b1,b2);
        }

        public override string ToString()
            => Format();
    }
}