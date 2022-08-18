//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class t_toggle : t_bits<t_toggle>
    {
        public void toggle_8i()
            => toggle_check<sbyte>();

        public void toggle_8u()
            => toggle_check<byte>();

        public void toggle_16i()
            => toggle_check<short>();

        public void toggle_16u()
            => toggle_check<ushort>();

        public void toggle_32i()
            => toggle_check<int>();

        public void toggle_32u()
            => toggle_check<uint>();

        public void toggle_64i()
            => toggle_check<long>();

        public void toggle_64u()
            => toggle_check<ulong>();

        public void toggle_32f()
            => toggle_check<float>();

        public void toggle_64f()
            => toggle_check<double>();

        void toggle_check<T>(T t = default)
            where T : unmanaged
        {
            var src = Random.Span<T>(RepCount);
            var tLen = width<T>();
            var srcLen = src.Length;
            for(var i = 0; i< srcLen; i++)
            {
                var x = src[i];
                for(byte j =0; j< tLen; j++)
                {
                    var before = gbits.test(x, j);
                    x = gbits.toggle(x, j);
                    var after = gbits.test(x, j);
                    NumericClaims.neq((uint)before, (uint)after);
                    x = gbits.toggle(x, j);
                    Claim.eq(x, src[i]);
                }
            }
        }

        public void bitsize()
        {
            PrimalClaims.eq((byte)8, width<byte>(w8));
            PrimalClaims.eq((byte)8, width<sbyte>(w8));
            PrimalClaims.eq((byte)16, width<short>(w8));
            PrimalClaims.eq((byte)16, width<ushort>(w8));
            PrimalClaims.eq((byte)32, width<int>(w8));
            PrimalClaims.eq((byte)32, width<uint>(w8));
            PrimalClaims.eq((byte)64, width<long>(w8));
            PrimalClaims.eq((byte)64, width<ulong>(w8));
            PrimalClaims.eq((byte)32, width<float>(w8));
            PrimalClaims.eq((byte)64, width<double>(w8));
        }

        public void testbit_outline()
        {
            Claim.require(bit.test(0b00000101, (byte)0));
            Claim.nea(bit.test(0b00000101, (byte)1));
            Claim.require(bit.test(0b00000101, (byte)2));

            Claim.require(bit.test(0b00000111, (byte)0));
            Claim.require(bit.test(0b00000111, (byte)1));
            Claim.require(bit.test(0b00000111, (byte)2));
        }

        public void enable_outline()
        {
            var x1 = (sbyte)0;
            var y1 = bits.enable(x1, 7);
            Claim.eq(SByte.MinValue, y1);
            ClaimPrimalSeq.eq("10000000", y1.ToBitString());

            var x2 = (byte)0;
            var y2 = bits.enable(x2, 7);
            Claim.eq(SByte.MinValue, (sbyte)y1);
            ClaimPrimalSeq.eq("10000000", y1.ToBitString());

            var x3 = -1;
            Claim.eq(x3 >> 10, -1);
        }
    }
}