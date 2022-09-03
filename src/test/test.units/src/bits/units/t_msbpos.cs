//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;
    using static core;

    public class t_mbspos : t_bits<t_mbspos>
    {
        public void msbpos_8()
            => check_msbpos<byte>();

        public void msbpos_16()
            => check_msbpos<ushort>();

        public void msbpos_32()
            => check_msbpos<uint>();

        public void msbpos_64()
            => check_msbpos<ulong>();

        void check_msbpos<T>(T t = default)
            where T : unmanaged
        {
            for(var i=0; i< RepCount; i++)
            {
                var x = Random.Next<T>();
                var xPos = gbits.msb(x);
                NumericClaims.lt(xPos, (byte)width<T>());

                var xCount = gbits.nlz(x);
                var y = BitStrings.scalar(x);
                var yCount = y.Nlz();
                NumericClaims.eq(xCount, yCount);

                var yPos = y.Length - 1 - yCount;
                Claim.eq(xPos,yPos);
            }
        }
    }
}