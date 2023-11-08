//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;

using api = Vex;

[ApiComplete]
public record struct VexC5 : IBitPattern<VexC5>
{
    // ~ R

    const byte R_Mask = 0b1000_0000;

    const byte R_Min = 7;

    const byte R_Max = 7;

    // ~ VVVV

    const byte VVVV_Mask = 0b0111_1000;

    const byte VVVV_Min = 3;

    const byte VVVV_Max = 6;

    // ~ L

    const byte L_Mask = 0b0000_0100;

    const byte L_Min = 2;

    const byte L_Max = 2;


    // ~ PP
    const byte PP_Mask = 0b0000_0011;

    const byte PP_Min = 0;

    const byte PP_Max = 1;

    [MethodImpl(Inline)]
    public static VexC5 init()
    {
        var dst = new VexC5();
        dst.B0 = (byte)VexPrefixKind.xC5;
        return dst;
    }

    [MethodImpl(Inline)]
    public static VexC5 init(bit r = default, byte vvvv = default, VL l = default, VexPP pp = default)
    {
        var dst = new VexC5();
        dst.B0 = (byte)VexPrefixKind.xC5;
        dst.R = r;
        dst.VVVV = vvvv;
        dst.L = l;
        dst.PP = pp;
        return dst;
    }

    [MethodImpl(Inline)]
    public static VexC5 define(byte b1)
    {
        var dst = new VexC5();
        dst.B0 = (byte)VexPrefixKind.xC5;
        dst.B1 = b1;
        return dst;
    }

    byte B0;

    byte B1;

    byte Unused1;

    byte Unused2;

    public bit R
    {
        [MethodImpl(Inline)]
        get => (bit)bits.extract(B1, R_Min, R_Max);

        [MethodImpl(Inline)]
        set => B1 = math.or(bits.scatter((byte)value, R_Mask), math.and(B1, math.not(R_Mask)));
    }

    public byte VVVV
    {
        [MethodImpl(Inline)]
        get => bits.extract(B1, VVVV_Min, VVVV_Max);

        [MethodImpl(Inline)]
        set => B1 = math.or(bits.scatter(value, VVVV_Mask), math.and(B1, math.not(VVVV_Mask)));
    }

    public VL L
    {
        [MethodImpl(Inline)]
        get => (AsmVL)bits.extract(B1, L_Min, L_Max);

        [MethodImpl(Inline)]
        set => B1 = math.or(bits.scatter((byte)value.Value, L_Mask), math.and(B1, math.not(L_Mask)));
    }

    public VexPP PP
    {
        [MethodImpl(Inline)]
        get => (VexPP)bits.extract(B1, PP_Min, PP_Max);

        [MethodImpl(Inline)]
        set => B1 =  math.or(bits.scatter((byte)value, PP_Mask), math.and(B1, math.not(PP_Mask)));
    }

    public VexPrefixKind Kind
    {
        [MethodImpl(Inline)]
        get => VexPrefixKind.xC5;
    }

    public byte Size
    {
        [MethodImpl(Inline)]
        get => api.size(Kind);
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

        BitRender.render1(R, ref i, dst);
        seek(dst,i++) = Chars.Space;

        BitRender.render4(VVVV, ref i, dst);
        seek(dst,i++) = Chars.Space;

        BitRender.render1((byte)L.Value, ref i, dst);
        seek(dst,i++) = Chars.Space;

        BitRender.render2((byte)PP, ref i, dst);

        return new string(slice(dst,0,i));
    }

    public string Format()
    {
        var b0 = B0.FormatHex(zpad:true, specifier:false, uppercase:false);
        var b1 = B1.FormatHex(zpad:true, specifier:false, uppercase:false);
        return string.Format("{0} {1}",b0,b1);
    }

    public override string ToString()
        => Format();
}
