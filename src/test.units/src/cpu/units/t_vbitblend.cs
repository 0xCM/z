//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static cpu;
    using static sys;

    public class t_vbitblend : t_inx<t_vbitblend>
    {
        public void bitblend_basecases()
        {
            var n = n256;
            var mask = cpu.vbroadcast(n, BitMasks.msb(n2,n1,z8));
            var zero = gcpu.vzero<byte>(n);
            var ones = gcpu.vones<byte>(n);
            var blend = gcpu.vselect<byte>(zero, ones, mask);
            Claim.veq(blend,mask);
        }

        public void bitblend_128x8u()
            => vbitblend_check<byte>(n128);

        public void vbitblend_128x16u()
            => vbitblend_check<ushort>(n128);

        public void vbitblend_128x32u()
            => vbitblend_check<uint>(n128);

        public void vbitblend_128x64u()
            => vbitblend_check<ulong>(n128);

        public void vbitblend_256x8u()
            => vbitblend_check<byte>(n256);

        public void vbitblend_256x16u()
            => vbitblend_check<ushort>(n256);

        public void vbitblend_256x32u()
            => vbitblend_check<uint>(n256);

        public void vbitblend_256x64u()
            => vbitblend_check<ulong>(n256);

        void vbitblend_check<T>(N256 w, T t = default)
            where T : unmanaged
        {
            var count = w/width<T>();
            for(var sample=0; sample<RepCount; sample++)
            {

                var x = Random.CpuVector<T>(w);
                var y = Random.CpuVector<T>(w);
                var mask = Random.CpuVector<T>(w);
                var blended = gcpu.vselect(x,y,mask);

                for(byte i = 0; i<count; i++)
                    Claim.eq(vcell(blended,i), gmath.blend(vcell(x,i), vcell(y,i), vcell(mask,i)));

                vcheckmask(x,y,mask,blended);
            }
        }

        void vcheckmask<T>(Vector256<T> left, Vector256<T> right, Vector256<T> mask, Vector256<T> result)
            where T : unmanaged
        {
            var ld = SpanBlocks.alloc<byte>(n256,1);

            var lbs = left.ToBitString();
            var rbs = right.ToBitString();
            var bsm = mask.ToBitString();
            var bsr = result.ToBitString();
            for(var i=0; i<lbs.Length; i++)
            {
                var a = bsm[i] ? rbs[i] : lbs[i];
                Claim.eq(a, bsr[i]);
            }
        }

        void vbitblend_check<T>(N128 w, T t = default)
            where T : unmanaged
        {
            var count = w/width<T>();
            for(var sample=0; sample<RepCount; sample++)
            {
                var x = Random.CpuVector<T>(w);
                var y = Random.CpuVector<T>(w);
                var m = Random.CpuVector<T>(w);
                var r = gcpu.vselect(x,y,m);

                for(byte i = 0; i<count; i++)
                    Claim.eq(vcell(r,i),gmath.blend(vcell(x,i),vcell(y,i), vcell(m,i)));
            }
        }
    }
}