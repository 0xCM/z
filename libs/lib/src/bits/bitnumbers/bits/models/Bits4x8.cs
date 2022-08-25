//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiComplete]
    public struct Bits4x8
    {
        [MethodImpl(Inline)]
        public static ref Bits4x8 write(uint4 src, byte offset, ref Bits4x8 dst)
        {
            ref var target = ref u32(dst);
            target = bits.bitcopy((uint)src << offset, offset, uint4.Width, target);
            return ref dst;
        }

        uint8b A;

        uint8b B;

        uint8b C;

        uint8b D;

        [MethodImpl(Inline)]
        public Bits4x8(uint src)
        {
            A = (byte)src;
            B = (byte)(src >> 8);
            C = (byte)(src >> 16);
            D = (byte)(src >> 24);
        }

        [MethodImpl(Inline)]
        public Bits4x8(ushort a, ushort b)
        {
            A = (byte)a;
            B = (byte)(a >> 8);
            C = (byte)b;
            D = (byte)(b >> 8);
        }

        [MethodImpl(Inline)]
        public Bits4x8(byte a, byte b, byte c, byte d)
        {
            A = a;
            B = b;
            C = c;
            D = c;
        }

        public uint4 A0
        {
            [MethodImpl(Inline)]
            get => A.Lo;

            [MethodImpl(Inline)]
            set => A = A.WithLo(value);
        }

        public uint4 A1
        {
            [MethodImpl(Inline)]
            get => A.Hi;

            [MethodImpl(Inline)]
            set => A = A.WithHi(value);
        }

        public uint4 B0
        {
            [MethodImpl(Inline)]
            get => B.Lo;

            [MethodImpl(Inline)]
            set => B = B.WithLo(value);
        }

        public uint4 B1
        {
            [MethodImpl(Inline)]
            get => B.Hi;

            [MethodImpl(Inline)]
            set => B = B.WithHi(value);
        }

        public uint4 C0
        {
            [MethodImpl(Inline)]
            get => C.Lo;

            [MethodImpl(Inline)]
            set => C = C.WithLo(value);
        }

        public uint4 C1
        {
            [MethodImpl(Inline)]
            get => C.Hi;

            [MethodImpl(Inline)]
            set => C = C.WithHi(value);
        }

        public uint4 D0
        {
            [MethodImpl(Inline)]
            get => D.Lo;

            [MethodImpl(Inline)]
            set => D = D.WithLo(value);
        }

        public uint4 D1
        {
            [MethodImpl(Inline)]
            get => D.Hi;

            [MethodImpl(Inline)]
            set => D = D.WithHi(value);
        }
    }
}