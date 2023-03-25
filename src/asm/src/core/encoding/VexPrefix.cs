//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;
    using static AsmPrefixCodes;

    using K = AsmPrefixCodes.VexPrefixKind;

    /// <remarks>
    /// [ Byte1[R | vvvv | L | pp] | Byte0[11000101b=0xC5]]
    /// [ Byte2[W | vvvv | L | pp] | Byte1[R | X | B | mmmmm] | Byte0[11000100b=0xC4]]
    /// R - REX.R in one's complement form
    /// X - REX.X in one's complement form
    /// B - REX.B in one's complement form
    /// mmmmm
    /// 00001 => specifies 0F leading opcode byte
    /// 00010 => specifies 0F38 leading opcode byte
    /// 00011 => specifies 0F3A Leading opcode byte
    /// vvvv - specifies a register in one's complement form
    /// L - specifies a length
    /// 0 => a scalar or 128-bit vector
    /// 1 => a 256-bit vector
    /// pp - opcode extension
    /// 00 => None
    /// 01 => 66
    /// 10 => F3
    /// 11 => F2
    /// </remarks>
    [ApiHost]
    public struct VexPrefix
    {
        [MethodImpl(Inline), Op]
        public static VexPrefix define(K kind, byte b1)
            => new VexPrefix(kind, b1);

        [MethodImpl(Inline), Op]
        public static VexPrefix define(K kind, byte b1, byte b2)
            => new VexPrefix(kind, b1, b2);

        [MethodImpl(Inline)]
        public static VexPrefixC4 c4(VexPrefix src)
        {
            var data = slice(bytes(src), 1, 2);
            return VexPrefixC4.define(skip(data,0), skip(data,1));
        }

        [MethodImpl(Inline)]
        public static VexPrefixC5 c5(VexPrefix src)
            => VexPrefixC5.define((byte)(src._Data >> 8));

        [MethodImpl(Inline)]
        public static BitfieldSeg<VexPrefixCode> code(ReadOnlySpan<byte> src)
        {
            var seg = BitfieldSeg<VexPrefixCode>.Empty;
            var count = src.Length;
            for(var i=z8; i<count; i++)
            {
                ref readonly var b = ref skip(src,i);
                if(b == (byte)VexPrefixCode.C4)
                {
                    seg = BitfieldSeg.define(VexPrefixCode.C4, i, 8);
                    break;
                }
                if(b == (byte)VexPrefixCode.C5)
                {
                    seg = BitfieldSeg.define(VexPrefixCode.C5, i, 8);
                    break;
                }
            }
            return seg;
        }

        [MethodImpl(Inline), Op]
        public static ushort leading(VexM src)
            => src switch {
                VexM.x0F => 0x0F,
                VexM.x0F38 => 0x0F38,
                VexM.x0F3A => 0x0F3A,
                _ => 0,
            };

        [MethodImpl(Inline), Op]
        public static ushort width(VexM src)
            => src switch {
                VexM.x0F => 8,
                VexM.x0F38 => 16,
                VexM.x0F3A => 16,
                _ => 0,
            };

        [MethodImpl(Inline), Op]
        public static ushort value(VexOpCodeExtension src)
            => src switch {
                VexOpCodeExtension.X66 => 0x66,
                VexOpCodeExtension.F2 => 0xF2,
                VexOpCodeExtension.F3 => 0xF3,
                _ => 0,
            };

        [MethodImpl(Inline), Op]
        public static byte size(VexPrefixCode src)
            => src switch{
                VexPrefixCode.C4 => 3,
                VexPrefixCode.C5 => 2,
                _ => 0
            };

        uint _Data;

        [MethodImpl(Inline)]
        internal VexPrefix(K k)
        {
            _Data = (byte)k;
        }

        [MethodImpl(Inline)]
        internal VexPrefix(K k, byte b1)
        {
            _Data = Bitfields.join((byte)k, b1, 0, 2);
        }

        [MethodImpl(Inline)]
        internal VexPrefix(K k, byte b1, byte b2)
        {
            _Data = Bitfields.join((byte)k, b1, b2, 3);
        }

        public byte Size
        {
            [MethodImpl(Inline)]
            get => (byte)(_Data >> 24);
        }

        [MethodImpl(Inline)]
        public K Kind()
            => (K)_Data;

        [MethodImpl(Inline)]
        public void Kind(K k)
            => _Data = Bytes.inject((byte)k,0, ref _Data);

        public string Format()
        {
            var kind = Kind();
            if(kind == K.xC4)
                return c4(this).Format();
            else if(kind == K.xC5)
                return c5(this).Format();
            else
                return EmptyString;
        }

        public override string ToString()
            => Format();

        public static VexPrefix Empty => default;
    }
}