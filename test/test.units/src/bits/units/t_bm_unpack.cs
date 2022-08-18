//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_bm_unpack : t_bits<t_bm_unpack>
    {
        public void bm_unpack_8x8x8()
        {
            var dst = Matrix.alloc<N8,byte>();
            var m = dst.ColCount;
            var n = dst.RowCount;
            for(var sample=0; sample<RepCount; sample++)
            {
                var src = Random.BitMatrix8();
                BitMatrix.unpack32(src, dst);

                for(var i=0; i< m; i++)
                for(var j=0; j< n; j++)
                    Claim.eq(src[i,j], dst[i,j] == 0 ? bit.Off : bit.On);
            }
        }

        public void bm_unpack_64x64x64()
        {
            var dst = Matrix.alloc<N64,ulong>();
            var m = dst.ColCount;
            var n = dst.RowCount;
            for(var sample=0; sample<RepCount; sample++)
            {
                var src = Random.BitMatrix64();
                BitMatrix.unpack32(src, dst);

                for(var i=0; i< m; i++)
                for(var j=0; j< n; j++)
                    Claim.eq(src[i,j], dst[i,j] == 0 ? bit.Off : bit.On);
            }
        }
    }
}