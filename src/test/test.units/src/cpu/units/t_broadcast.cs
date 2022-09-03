//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_broadcast : t_inx<t_broadcast>
    {
        public void t_broadcast_case1()
        {
            ulong pattern = 0b11001100;
            var expect =
                pattern << 0  | pattern << 8  | pattern << 16 | pattern << 24 |
                pattern << 32 | pattern << 40 | pattern << 48 | pattern << 56;
            var actual = gcpu.broadcast<byte,ulong>((byte)pattern);
            PrimalClaims.eq(expect,actual);
        }

        public void t_broadcast_case2()
        {
            ulong pattern = ushort.MaxValue;
            var expect = pattern << 0 | pattern << 16 | pattern << 32 | pattern << 48;
            var actual = gcpu.broadcast<ushort,ulong>((ushort)pattern);
            PrimalClaims.eq(expect,actual);
        }

        public void t_broadcast_case3()
        {
            ulong pattern = uint.MaxValue;
            var expect = pattern << 0 | pattern << 32;
            var actual = gcpu.broadcast<uint,ulong>((uint)pattern);
            PrimalClaims.eq(expect,actual);
        }

        public void t_broadcast_case4()
        {
            ulong pattern = ulong.MaxValue;
            var expect = byte.MaxValue;
            var actual = gcpu.broadcast<ulong,byte>(pattern);
            PrimalClaims.eq(expect,actual);
        }
    }
}