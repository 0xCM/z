//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;

[BitPattern(Pattern)]
public readonly record struct EvexPrefix : IBitPattern<EvexPrefix>
{
    const string Pattern = "01100010" + "z VL b f aaa" +  "W vvvv 1 pp" + "RXB q 0 mmm";

    readonly uint Data;

    [MethodImpl(Inline)]
    internal EvexPrefix(uint data)
    {
        Data = data;
    }

    public ref readonly Hex8 this[uint i]
    {
        [UnscopedRef, MethodImpl(Inline)]
        get => ref skip(Bytes,i);
    }

    public ref readonly Hex8 this[int i]
    {
        [UnscopedRef, MethodImpl(Inline)]
        get => ref skip(Bytes,i);
    }

    public Span<Hex8> Bytes
    {
        [UnscopedRef]
        get => recover<Hex8>(bytes(Data));
    }

    ref P0 p0
    {
        [UnscopedRef]
        get => ref @as<Hex8,P0>(seek(Bytes,1));
    }

    ref P1 p1
    {
        [UnscopedRef]
        get => ref @as<Hex8,P1>(seek(Bytes,2));
    }

    ref P2 p2
    {
        [UnscopedRef]
        get => ref @as<Hex8,P2>(seek(Bytes,3));
    }

    /// <summary>
    /// EVEX.mmm: Access to up to eight decoding maps; Currently, only the following decoding maps are supported: 1,2, 3, 5, and 6.
    /// </summary>
    public readonly num3 mmm => p0.mmm;

    /// <summary>
    /// Evex.R': Combine with EVEX.R and ModR/M.reg; This bit is stored in inverted format
    /// </summary>
    public readonly bit Rp=> p0.Rp;

    /// <summary>
    /// EVEX.RXB: Next-8 register specifier modifier; Combine with ModR/M.reg, ModR/M.rm (base, index/vidx). This field is encoded in bit inverted format.
    /// </summary>
    public readonly num3 RXB => p0.RXB;

    /// <summary>
    /// EVEX.pp: Compressed legacy prefix; Identical to VEX.pp
    /// </summary>
    public readonly VexPP pp => (VexPP)(byte)p1.pp;
        
    /// <summary>
    /// EVEX.vvvv: VVVV register specifier; Same as VEX.vvvv. This field is encoded in bit inverted format.
    /// </summary>
    public readonly num4 vvvv => p1.vvvv;

    /// <summary>
    /// EVEX.W: Operand size promotion/Opcode extension
    /// </summary>
    public readonly bit W => p1.W;

    /// <summary>
    /// EVEX.aaa: Embedded opmask register specifier
    /// </summary>
    public readonly num3 aaa => p2.aaa;

    /// <summary>
    /// EVEX.V': High-16 VVVV/VIDX register specifier; Combine with EVEX.vvvv or when VSIB present. This bit is stored in inverted format.
    /// </summary>
    public readonly bit Vp  => p2.Vp;   

    /// <summary>
    /// EVEX.b: Broadcast/RC/SAE Context
    /// </summary>
    public readonly bit b => p2.b;

    /// <summary>
    /// EVEX.L'L Vector length/RC
    /// </summary>
    public readonly VL VL => (AsmVL)(byte)p2.VL;

    /// <summary>
    /// EVEX.z Zeroing/Merging
    /// </summary>
    public readonly bit z => p2.z;   

    [StructLayout(LayoutKind.Sequential,Size=1)]
    readonly record struct P0
    {
        public num3 RXB => num3.number(bits.extract(this,5,7));

        public bit Rp => bits.test(this,4);

        public num3 mmm => num3.number(bits.extract(this, 0,2));

        public string Format()
            => u8(this).FormatHex();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator byte(P0 src)
            =>@as<P0,byte>(src);

        [MethodImpl(Inline)]
        public static implicit operator P0(byte src)
            => @as<byte,P0>(src);
    }

    [StructLayout(LayoutKind.Sequential,Size=1)]
    readonly record struct P1
    {
        public bit W => bits.test(this,7);

        public num4 vvvv => num4.number(bits.extract(this,3,6));

        public num2 pp => new(bits.extract(this, 0,1));

        public string Format()
            => u8(this).FormatHex();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator byte(P1 src)
            => @as<P1,byte>(src);

        [MethodImpl(Inline)]
        public static implicit operator P1(byte src)
            => @as<byte,P1>(src);
    }

    [StructLayout(LayoutKind.Sequential,Size=1)]
    readonly record struct P2
    {
        public bit z => bits.test(this,7);

        public num2 VL => bits.extract(this,5, 6);

        public bit b => bits.test(this,4);

        public bit Vp => bits.test(this,3);

        public num3 aaa => bits.extract(this,0,2);

        public string Format()
            => u8(this).FormatHex();        
        
        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator byte(P2 src)
            => @as<P2,byte>(src);

        [MethodImpl(Inline)]
        public static implicit operator P2(byte src)
            => @as<byte,P2>(src);
    }

    public string Format()
        => Data == 0 ? EmptyString : $"{((byte)Data).FormatHex()} {p0} {p1} {p2}";

    public override string ToString()
        => Format();

    public ReadOnlySpan<char> Bitstring
        => BitRender.format32x4(Data);

    public static EvexPrefix Empty => default;
}
