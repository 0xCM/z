//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;

public readonly record struct EvexPrefix
{
    [MethodImpl(Inline)]
    public static bit test(ReadOnlySpan<byte> src)
    {
        if(src.Length < 4)
            return false;
        else
            return first(src) == 0x62;
    }

    readonly uint Data;

    [MethodImpl(Inline)]
    internal EvexPrefix(uint data)
    {
        Data = data;
    }

    public Span<byte> Bytes
    {
        [UnscopedRef]
        get => bytes(Data);
    }

    public ref P0 p0
    {
        [UnscopedRef]
        get => ref @as<P0>(seek(Bytes,1));
    }

    public ref P1 p1
    {
        [UnscopedRef]
        get => ref @as<P1>(seek(Bytes,2));
    }

    public ref P2 p2
    {
        [UnscopedRef]
        get => ref @as<P2>(seek(Bytes,3));
    }

    [StructLayout(LayoutKind.Sequential,Size=1)]
    public readonly record struct P0
    {
        /// <summary>
        /// EVEX.mmm: Access to up to eight decoding maps; Currently, only the following decoding maps are supported: 1,2, 3, 5, and 6.
        /// </summary>
        public num3 mmm => new(this);

        /// <summary>
        /// Evex.R': High-16 register specifier modifier; This bit is stored in inverted format.
        /// </summary>
        public bit Rp => ~bits.test(this,4);

        /// <summary>
        /// EVEX.RXB: Next-8 register specifier modifier; Combine with ModR/M.reg, ModR/M.rm (base, index/vidx).
        /// This field is encoded in bit inverted format.
        /// </summary>
        public num3 RXB => ~new num3(this);

        public string Format()
            => $"RXB:{RXB.Bitstring()} R':{Rp} mmm:{mmm.Bitstring()}";

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
    public readonly record struct P1
    {
        /// <summary>
        /// EVEX.pp: Compressed legacy prefix; Identical to VEX.pp
        /// </summary>
        public num2 pp => new(this);

        /// <summary>
        /// EVEX.vvvv: VVVV register specifier; Same as VEX.vvvv. This field is encoded in bit inverted format.
        /// </summary>
        public num4 vvvv =>  ~new num4(bits.extract(this,3,6));

        /// <summary>
        /// EVEX.W: Operand size promotion/Opcode extension
        /// </summary>
        public bit W => bits.test(this,7);

        public string Format()
            => $"W:{W} vvvv:{vvvv.Bitstring()} pp:{pp.Bitstring()}";

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
    public readonly record struct P2
    {
        /// <summary>
        /// EVEX.aaa: Embedded opmask register specifier
        /// </summary>
        public num3 aaa => new(this);

        /// <summary>
        /// EVEX.V': High-16 VVVV/VIDX register specifier; Combine with EVEX.vvvv or when VSIB present. This bit is stored in inverted format.
        /// </summary>
        public bit Vp => ~bits.test(this,3);

        /// <summary>
        /// EVEX.b: Broadcast/RC/SAE Context
        /// </summary>
        public bit b => bits.test(this,4);

        /// <summary>
        /// EVEX.L'L Vector length/RC
        /// </summary>
        public num2 LpL => bits.extract(this,5, 6);

        /// <summary>
        /// EVEX.z Zeroing/Merging
        /// </summary>
        public bit z => bits.test(this,7);

        public string Format()
            => $"z:{z} L'L:{LpL.Bitstring()} b:{b} V':{Vp} aaa:{aaa.Bitstring()}";
        
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
        => Data == 0 ? EmptyString : $"0x62 [{p0}] [{p1}] [{p2}]";

    public override string ToString()
        => Format();

    public ReadOnlySpan<char> Bitstring
        => BitRender.format32x4(Data);

    public static EvexPrefix Empty => default;
}
