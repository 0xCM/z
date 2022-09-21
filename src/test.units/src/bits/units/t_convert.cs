//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class t_convert : UnitTest<t_convert>
    {
        public void convert_32u_to_bytes_check()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.Next<uint>();
                var y = x.Bytes();
                Span<byte> z = BitConverter.GetBytes(x);
                ClaimNumeric.eq(y,z);
            }
        }

        public void convert_64u_to_bytes_check()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.Next<ulong>();
                var y = x.Bytes();
                Span<byte> z = BitConverter.GetBytes(x);
                ClaimNumeric.eq(y,z);
            }
        }

        public void convert_64f_to_bytes_check()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.Next<double>();
                var y = ByteReader.read8(x);
                Span<byte> z = BitConverter.GetBytes(x);
                ClaimNumeric.eq(y,z);
            }
        }
    }
}