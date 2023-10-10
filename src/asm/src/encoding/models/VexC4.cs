//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static AsmPrefixTokens;
using static sys;

[DataWidth(24), ApiComplete]
public record struct VexC4
{
    // ~ RXB
    const byte RXB_Mask = 0b1110_0000;

    const byte RXB_Min = 5;

    const byte RXB_Max = 7;

    const byte RXB_Width = RXB_Max - RXB_Min + 1;

    // ~ M
    const byte MMMMM_Mask = 0b0001_1111;

    const byte MMMMM_Min = 0;

    const byte MMMMM_Max = 4;

    const byte MMMMM_Width = MMMMM_Max - MMMMM_Min + 1;

    // ~ W

    const byte W_Mask = 0b1000_0000;

    const byte W_Min = 7;

    const byte W_Max = 7;

    const byte W_Width = W_Max - W_Min + 1;

    // ~ VVVV

    const byte VVVV_Mask = 0b0111_1000;

    const byte VVVV_Min = 3;

    const byte VVVV_Max = 6;

    const byte VVVV_Width = VVVV_Max - VVVV_Min + 1;

    // ~ L

    const byte L_Mask = 0b0000_0100;

    const byte L_Min = 2;

    const byte L_Max = 2;

    const byte L_Width = L_Max - L_Min + 1;

    // ~ PP

    const byte PP_Mask = 0b0000_0011;

    const byte PP_Min = 0;

    const byte PP_Max = 1;

    const byte PP_Width = PP_Max - PP_Min + 1;

    [MethodImpl(Inline)]
    public static VexC4 init()
    {
        var dst = new VexC4();
        dst.B0 = (byte)VexPrefixKind.xC4;
        return dst;
    }

    [MethodImpl(Inline)]
    public static VexC4 init(VexRXB rxb, VexM mmmmm = default, bit w = default, byte vvvv = default, VexLengthCode l = default, VexOpCodeExtension pp = default)
    {
        var dst = new VexC4();
        dst.B0 = (byte)VexPrefixKind.xC4;
        dst.RXB = rxb;
        dst.MMMMM = mmmmm;
        dst.W = w;
        dst.VVVV = vvvv;
        dst.L = l;
        dst.PP = pp;
        return dst;
    }

    [MethodImpl(Inline)]
    public static VexC4 define(byte b1, byte b2)
    {
        var dst = new VexC4();
        dst.B0 = (byte)VexPrefixKind.xC4;
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

    public VexM MMMMM
    {
        [MethodImpl(Inline)]
        get => (VexM)bits.extract(B1, MMMMM_Min, MMMMM_Max);

        [MethodImpl(Inline)]
        set => B1 = math.or(bits.scatter((byte)value, MMMMM_Mask), math.and(B1, math.not(MMMMM_Mask)));
    }

    public bit W
    {
        [MethodImpl(Inline)]
        get => (bit)bits.extract(B2, W_Min, W_Max);

        [MethodImpl(Inline)]
        set => B2 = math.or(bits.scatter((byte)value, W_Mask), math.and(B2, math.not(W_Mask)));
    }

    public byte VVVV
    {
        [MethodImpl(Inline)]
        get => bits.extract(B2, VVVV_Min, VVVV_Max);

        [MethodImpl(Inline)]
        set => B2 = math.or(bits.scatter((byte)value, VVVV_Mask), math.and(B2, math.not(VVVV_Mask)));
    }

    public VexLengthCode L
    {
        [MethodImpl(Inline)]
        get => (VexLengthCode)bits.extract(B2, L_Min, L_Max);

        [MethodImpl(Inline)]
        set => B2 = math.or(bits.scatter((byte)value, L_Mask), math.and(B2, math.not(L_Mask)));
    }

    public VexOpCodeExtension PP
    {
        [MethodImpl(Inline)]
        get => (VexOpCodeExtension)bits.extract(B2, PP_Min, PP_Max);

        [MethodImpl(Inline)]
        set => B2 =  math.or(bits.scatter((byte)value, PP_Mask), math.and(B2, math.not(PP_Mask)));
    }

    const string SemanticFormat = "{0}\n{1}\n{2}";

    public VexPrefixKind Kind
    {
        [MethodImpl(Inline)]
        get => VexPrefixKind.xC4;
    }

    public RegIndex Reg
    {
        [MethodImpl(Inline)]
        get => (RegIndex)math.not(VVVV);
    }

    public byte Size
    {
        [MethodImpl(Inline)]
        get => VexPrefix.size(Kind);
    }

    public string Bitstring()
    {
        var storage = CharBlock64.Empty;
        var dst = storage.Data;
        var i=0u;
        BitRender.render8(B0, ref i, dst);
        seek(dst,i++) = Chars.Space;

        BitRender.render3((byte)RXB, ref i, dst);
        seek(dst,i++) = Chars.Space;

        BitRender.render5((byte)MMMMM, ref i, dst);
        seek(dst,i++) = Chars.Space;

        BitRender.render1((byte)W, ref i, dst);
        seek(dst,i++) = Chars.Space;

        BitRender.render4(VVVV, ref i, dst);
        seek(dst,i++) = Chars.Space;

        BitRender.render1((byte)L, ref i, dst);
        seek(dst,i++) = Chars.Space;

        BitRender.render2((byte)PP, ref i, dst);

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
