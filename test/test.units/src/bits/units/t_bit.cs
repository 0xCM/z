//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static bit;

    public sealed class t_bit : UnitTest<t_bit>
    {
        public void check_parse()
        {
            Claim.eq(Off, bit.parse('0'));
            Claim.eq(On, bit.parse('1'));
        }

        public void check_add()
        {
            Claim.nea(Off + Off);
            Claim.require(On + Off);
            Claim.require(Off + On);
            Claim.nea(On + On);
        }

        public void check_and()
        {
            Claim.nea(Off && Off);
            Claim.nea(On && Off);
            Claim.nea(Off && On);
            Claim.require(On && On);
        }

        public void check_or()
        {
            Claim.nea(Off || Off);
            Claim.require(On || Off);
            Claim.require(Off || On);
            Claim.require(On || On);
        }

        public void check_xor()
        {
            Claim.nea(Off ^ Off);
            Claim.require(On ^ Off);
            Claim.require(Off ^ On);
            Claim.nea(On ^ On);
        }

        public void check_not()
        {
            Claim.require(~Off);
            Claim.require(!Off);
            Claim.nea(~On);
            Claim.nea(!On);
        }

        public void check_nand()
        {
            Claim.require(bit.nand(Off, Off));
            Claim.require(bit.nand(On, Off));
            Claim.require(bit.nand(Off, On));
            Claim.nea(bit.nand(On, On));
        }

        public void check_nor()
        {
            Claim.require(bit.nor(Off, Off));
            Claim.nea(bit.nor(On, Off));
            Claim.nea(bit.nor(Off, On));
            Claim.nea(bit.nor(On, On));
        }

        public void check_xnor()
        {
            Claim.require(bit.xnor(Off, Off));
            Claim.nea(bit.xnor(On, Off));
            Claim.nea(bit.xnor(Off, On));
            Claim.require(bit.xnor(On, On));
        }

        public void check_eq()
        {
            Claim.require(Off == Off);
            Claim.require(On != Off);
            Claim.require(Off != On);
            Claim.require(On == On);
        }

        public void check_convert()
        {
            Claim.eq((byte)0, (byte)Off);
            Claim.eq((byte)1, (byte)On);

            Claim.eq((ushort)0, (ushort)Off);
            Claim.eq((ushort)1, (ushort)On);

            Claim.eq(0u, (uint)Off);
            Claim.eq(1u, (uint)On);

            Claim.eq(0ul, (ulong)Off);
            Claim.eq(1ul, (ulong)On);
        }
    }
}