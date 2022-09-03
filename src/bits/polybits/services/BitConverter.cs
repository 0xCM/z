//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// Converts <typeparamref name='N'/>-bit number representations
    /// </summary>
    public readonly struct BitConverter<N>
        where N : unmanaged, ITypeNat
    {
        // 65472 0xFFC0 0b1111111111000000
        const string RenderPattern = "{0:D5} 0x{0:X4} 0b{1}";

        const byte SepLength = 1;

        const byte DecOffset = 0;

        const byte DecLength = 5;

        const byte HexSegOffset = DecOffset + DecLength + SepLength;

        const byte HexSpecLength = 2;

        const byte HexValLength = 4;

        const byte HexSegLength = HexSpecLength + HexValLength;

        const byte HexValOffset = HexSegOffset + HexSpecLength;

        const byte BinSegOffset =  HexSegOffset + HexSegLength + SepLength;

        const byte BinSpecLength = 2;

        const byte BinValOffset = BinSegOffset + BinSpecLength;

        const byte BinValLength = 16;

        readonly Index<asci32> Data;

        [MethodImpl(Inline)]
        internal BitConverter(Index<asci32> data)
        {
            Data = data;
        }

        [MethodImpl(Inline)]
        ref readonly asci32 Entry(ushort value)
            => ref Data[value];

        [MethodImpl(Inline)]
        public ref readonly asci4 Chars(Base16 @base, ushort value)
        {
            ref readonly var entry = ref Data[value];
            ref readonly var seg = ref @as<asci4>(slice(entry.View, HexValOffset, HexValLength));
            return ref seg;
        }

        [MethodImpl(Inline)]
        public ref readonly asci16 Chars(Base2 @base, ushort value)
        {
            ref readonly var entry = ref Entry(value);
            ref readonly var seg = ref @as<asci16>(slice(entry.View, BinValOffset, BinValLength));
            return ref seg;
        }
    }
}