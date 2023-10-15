//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_bitpack_unpack : t_bits<t_bitpack_unpack>
    {
        public void unpack_64x1()
        {
            Span<byte> dst = stackalloc byte[64];

            for(var i=0; i< RepCount; i++)
            {
                var src = Random.Next<ulong>();
                BitPack.unpack1x64x8(src, dst);
                var bitsPC = dst.PopCount();
                var bytes = sys.bytes(src);
                var bytesPC = bytes.PopCount();
                Claim.eq(bitsPC, bytesPC);
            }
        }

        public void unpack_32x1()
        {
            Span<byte> y1 = stackalloc byte[32];
            Span<byte> y2 = stackalloc byte[32];
            for(var i=0; i< RepCount; i++)
            {
                var x = Random.Next<uint>();
                BitPack.unpack1x32x8(x, ref sys.seek(y1,i));
                BitPack.unpack1x32x8(x, ref sys.seek(y2,i));
                Claim.eq(y1.ToBitString(), y2.ToBitString());
            }
        }
    }
}